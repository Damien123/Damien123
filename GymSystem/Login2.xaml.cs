using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

using System.Threading;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace GymSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login2 : Window
    {
        public BackgroundWorker bw = new BackgroundWorker();

        //Global list of user records
        List<Member> memberList = new List<Member>();
        List<Staff> staffList = new List<Staff>();
        gymDatabaseEntities dbEntities = new gymDatabaseEntities();
        gymDatabaseEntities dbEntities2 = new gymDatabaseEntities();

        public Login2()
        {
            InitializeComponent();


            ///create a Background Worker process for extra functionality to work with alternative login code at bottom of screen
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
           // bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            ///bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
           // bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }


        //////////////////////////////////////METHODS///////////////////////////////////////////////////////
        /// <summary>
        /// The following number  of methods will load from the Staff Database and test the login credentials against the user access lever!!!
        /// </summary>
        /// 

        private void mtdLoadUsers()
        {
            //Clear contents of the userList
            staffList.Clear();
            foreach (var staff in dbEntities.Staffs)
            {
                //Add all users to the global user list
                staffList.Add(staff);
            }
            //Clear contents of the userList
            memberList.Clear();
            foreach (var member in dbEntities2.Members)
            {
                //Add all users to the global user list
                memberList.Add(member);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Pre-load users into the User global list
            ////  mtdLoadUsersMembers();
            mtdLoadUsers();
            /////////////////////////////////tester///////////////////////////
        }


        private Staff mtdGetUserDetails(string username, string password)
        {
            Staff userDetails = new Staff();
            foreach (var staff in staffList)
            {
                //Check each user name and password in the global list to see if it matches
                //the inputted user name and password
                if
                (username == staff.UserName.Trim() && password == staff.Password.Trim())//// Testing -> && staff.Password == "1")
                {
                    //If there is a match then add the details to the local user account
                    userDetails = staff;
                }
            }
            //Return the user details
            return userDetails;
        }

        private Member mtdGetMembersDetails(string username, string password)
        {
            Member memberDetails = new Member();
            foreach (var member in memberList)
            {
                //Check each user name and password in the global list to see if it matches
                //the inputted user name and password
                if
                (username == member.UserName.Trim() && password == member.Password.Trim())//// Testing -> && staff.Password == "1")
                {
                    //If there is a match then add the details to the local user account
                    memberDetails = member;
                }
            }
            //Return the user details
            return memberDetails;
        }

        //////////////////////////////////////Click Events///////////////////////////////////////////////////////



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MembersMenu mm = new MembersMenu();
            mm.Show();
            this.Close();
            Environment.Exit(0);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //
            /// String userName = tbxUsername.Text.ToLower();
            /// string pass = tbxPassword.Password;
            /// 
           // lblLoading.Visibility = Visibility.Hidden;
           // lblForgetPw.Visibility = Visibility.Hidden;
        //    lblLoading.Visibility = Visibility.Visible;
         
            tbxUsername.IsEnabled = false;
            tbxPassword.IsEnabled = false;
            btnLogin.IsEnabled = false;

            //Create an instance of a user class
            Staff staffDetails = new Staff();
            //Get the user name from the tbxUserName textbox. Remove unnecessary spaces
            string currentUser = tbxUsername.Text.Trim();
            ///currentUser = tbxUsername.Text.ToLower();
            //Get password text. Note it does not use the same syntax as a normal text box
            string currentPassword = tbxPassword.Password;
           /// currentPassword = tbxUsername.Text.ToLower();
            //Run the mtdGetUserDetails method with the inputted user name and password information       
            staffDetails = mtdGetUserDetails(currentUser, currentPassword);


            if (staffDetails.AccessLevel == 1)            
            {
                Mouse.OverrideCursor = Cursors.Wait;
                
                lblLoading.Visibility = Visibility.Visible;
                //lblLoading.Content = "LOGIN SUCCESSFUL";//place in ForgetPassword label instead!
                Thread.Sleep(3000);
                //proceed with the successfull login procedure
                       
                //display the Next Window of the GymSystem
                this.Hide();
                Mouse.OverrideCursor = Cursors.Arrow;
                AdminMenu mw = new AdminMenu();
                mw.Show();
                }

            else if (staffDetails.AccessLevel == 2)//Admin LEVEL
            {
               // Thread.Sleep(5000);
                this.Hide();
                MainWindow mw = new MainWindow();//STAFFwindow
                mw.staff = staffDetails;
                mw.Show();
                // mw.ShowDialog();
            }

            else
            {
               
                // lblLoading.Visibility = Visibility.Hidden;
                lblForgetPw.Visibility = Visibility.Hidden;
               // lblForgetPw.Content = "FORGET PASSWORD ?";
                tbxUsername.IsEnabled = true;
                tbxUsername.BorderBrush = Brushes.Red;
                tbxPassword.IsEnabled = true;
                tbxPassword.BorderBrush = Brushes.Red;
                btnLogin.IsEnabled = true;
                Mouse.OverrideCursor = null;
                MessageBox.Show("Please enter the correct Username and Password!");
                tbxUsername.Clear();
                tbxPassword.Clear();
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //Create an instance of a user class
            Member memberDetails = new Member();////////////////////////////////////////////////tester///////
            //Get the user name from the tbxUserName textbox. Remove unnecessary spaces
            string currentUser = tbxUsername.Text.Trim();
            //Get password text. Note it does not use the same syntax as a normal text box
            string currentPassword = tbxPassword.Password;
            //Run the mtdGetUserDetails method with the inputted user name and password information       
            memberDetails = mtdGetMembersDetails(currentUser, currentPassword);////tester//////////////

            if (memberDetails.Accesslevel == 1)//Admin LEVEL
            {
                this.Hide();
                MembersMenu mm = new MembersMenu();//STAFFwindow
                mm.member = memberDetails;
                mm.Show();
                // mw.ShowDialog();
            }
            else
            {
                // lblLoginAdvice.Content = "Invalid details!";
                MessageBox.Show("Please enter the correct Username and Password!");
                tbxUsername.Text = "";
                tbxPassword.Password = "";
                tbxUsername.Focus();
            }
        }
    }
}


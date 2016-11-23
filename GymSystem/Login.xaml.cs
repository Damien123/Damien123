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
using System.Data;

using System.Threading;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace GymSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public BackgroundWorker bw = new BackgroundWorker();

        //Global list of user records
        List<Member> memberList = new List<Member>();
        List<Staff> staffList = new List<Staff>();
        gymDatabaseEntities dbEntities = new gymDatabaseEntities();
        gymDatabaseEntities dbEntities2 = new gymDatabaseEntities();

        public Login()
        {
            InitializeComponent();
           
            
          //  ///create a Background Worker process for extra functionality to work with alternative login code at bottom of screen
          //  bw.WorkerReportsProgress = true;
          //  bw.WorkerSupportsCancellation = true;
          //  bw.DoWork += new DoWorkEventHandler(bw_DoWork);
          ////  bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
          //  bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }



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

    //////    private void mtdLoadUsersMembers()////////////////////////tester///////////////////////////
    //////{
    //////    //Clear contents of the userList
    //////    memberList.Clear();
    //////    foreach (var member in dbEntities2.Members)
    //////    {
    //////        //Add all users to the global user list
    //////        memberList.Add(member);
    //////    }
    //////}

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
       

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Damien\Source\Repos\Damien123\GymSystem\gymDatabase.mdf;Integrated Security=True");

            //Create an instance of a user class
            Staff staffDetails = new Staff();
       ///     Member memberDetails = new Member();////////////////////////////////////////////////tester///////
            //Get the user name from the tbxUserName textbox. Remove unnecessary spaces
            string currentUser = tbxUsername.Text.Trim();
            //Get password text. Note it does not use the same syntax as a normal text box
            string currentPassword = tbxPassword.Password;
            //Run the mtdGetUserDetails method with the inputted user name and password information       
            staffDetails = mtdGetUserDetails(currentUser, currentPassword);       
     ///       memberDetails = mtdGetMembersDetails(currentUser, currentPassword);////tester//////////////

            ////if (memberDetails.Accesslevel == 1)//Admin LEVEL
            ////{
            ////    this.Hide();
            ////    MembersMenu mm = new MembersMenu();//STAFFwindow
            ////    mm.member = memberDetails;
            ////    mm.Show();
            ////    // mw.ShowDialog();
            ////}
           

            if (staffDetails.AccessLevel == 1)//Admin LEVEL
            {
                this.Hide();
                AdminMenu am = new AdminMenu();//STAFFwindow
                am.staff = staffDetails;
                am.Show();
                // mw.ShowDialog();
            }

            else if (staffDetails.AccessLevel == 2)//Admin LEVEL
            {
                this.Hide();
                MainWindow mw = new MainWindow();//STAFFwindow
                mw.staff = staffDetails;
                mw.Show();
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
            ////else if (staffDetails.AccessLevel >= 2 && staffDetails.AccessLevel < 3)//Admin LEVEL
            ////{
            ////    this.Hide();
            ////   AdminMenu mw = new AdminMenu();
            ////   // mw.staff = staffDetails;///dont need this?????##################
            ////    mw.Show();
            ////    // mw.ShowDialog();
            ////}
            //else if (adminDetails.AccessLevel > 1)//STAFF LEVEL//////////////////tester///////////
            //{
            //    this.Hide();
            //    AdminMenu mw = new AdminMenu();
            //    mw.admin = adminDetails;
            //    mw.Show();
            //    // mw.ShowDialog();
            //}



        }


        //Alternative LOGIN BUTTON CLICK!!!
        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow mw = new MainWindow();
        //    mw.Show();
        //    this.Close();
        //}

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MembersMenu mm = new MembersMenu();
            mm.Show();
            this.Close();
            Environment.Exit(0);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //Create an instance of a user class
         ///   Staff staffDetails = new Staff();
            Member memberDetails = new Member();////////////////////////////////////////////////tester///////
            //Get the user name from the tbxUserName textbox. Remove unnecessary spaces
            string currentUser = tbxUsername.Text.Trim();
            //Get password text. Note it does not use the same syntax as a normal text box
            string currentPassword = tbxPassword.Password;
            //Run the mtdGetUserDetails method with the inputted user name and password information       
       ///     staffDetails = mtdGetUserDetails(currentUser, currentPassword);
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
            

            ////else if (staffDetails.AccessLevel == 1)//Admin LEVEL
            ////{
            ////    this.Hide();
            ////    MainWindow mw = new MainWindow();//STAFFwindow
            ////    mw.staff = staffDetails;
            ////    mw.Show();
            ////    // mw.ShowDialog();
            ////}
            ////else
            ////{
            ////    // lblLoginAdvice.Content = "Invalid details!";
            ////    MessageBox.Show("Please enter the correct Username and Password!");
            ////    tbxUsername.Text = "";
            ////    tbxPassword.Password = "";
            ////    tbxUsername.Focus();
            ////}
            ////else if (staffDetails.AccessLevel >= 2 && staffDetails.AccessLevel < 3)//Admin LEVEL
            ////{
            ////    this.Hide();
            ////   AdminMenu mw = new AdminMenu();
            ////   // mw.staff = staffDetails;///dont need this?????##################
            ////    mw.Show();
            ////    // mw.ShowDialog();
            ////}
            //else if (adminDetails.AccessLevel > 1)//STAFF LEVEL//////////////////tester///////////
            //{
            //    this.Hide();
            //    AdminMenu mw = new AdminMenu();
            //    mw.admin = adminDetails;
            //    mw.Show();
            //    // mw.ShowDialog();
            //}
        }
    }
}

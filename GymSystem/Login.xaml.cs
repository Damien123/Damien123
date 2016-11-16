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
    public partial class Login : Window
    {
        public BackgroundWorker bw = new BackgroundWorker();

        //Global list of user records
        List<Staff> staffList = new List<Staff>();
        gymDatabaseEntities dbEntities = new gymDatabaseEntities();

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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Pre-load users into the User global list
            mtdLoadUsers();
        }


        private Staff mtdGetUserDetails(string username, string password)
        {
            Staff userDetails = new Staff();
            foreach (var staff in staffList)
            {
                //Check each user name and password in the global list to see if it matches
                //the inputted user name and password
                if
                (username == staff.UserName && password == staff.Password)
                {
                    //If there is a match then add the details to the local user account
                    userDetails = staff;
                }
            }
            //Return the user details
            return userDetails;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Damien\Source\Repos\Damien123\GymSystem\gymDatabase.mdf;Integrated Security=True");

            //Create an instance of a user class
            Staff staffDetails = new Staff();
            //Get the user name from the tbxUserName textbox. Remove unnecessary spaces
            string currentUser = tbxUsername.Text.Trim();
            //Get password text. Note it does not use the same syntax as a normal text box
            string currentPassword = tbxPassword.Password;
            //Run the mtdGetUserDetails method with the inputted user name and password information       
            staffDetails = mtdGetUserDetails(currentUser, currentPassword);


            if (staffDetails.AccessLevel > 0)
            {
                this.Hide();
                MainWindow mw = new MainWindow();
                mw.staff = staffDetails;
                mw.Show();
                // mw.ShowDialog();
            }
            if (staffDetails.UserName == "D")
            {
                this.Hide();
                MainWindow mw = new MainWindow();
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



        ///Alternative login Minus the Database connection!!!////////////////////////



        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //}

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    //
        //    String userName = tbxUsername.Text.ToLower();
        //    string pass = tbxPassword.Password;
        //    lblForgetPw.Visibility = Visibility.Hidden;
        //    lblLoading.Visibility = Visibility.Visible;
        //    Mouse.OverrideCursor = Cursors.Wait;
        //    tbxUsername.IsEnabled = false;
        //    tbxPassword.IsEnabled = false;
        //    btnLogin.IsEnabled = false;

        //    if (userName == "d" && pass == "d")
        //    {
        //        if (bw.IsBusy == false)
        //        {
        //            bw.RunWorkerAsync();
        //        }
        //    }
        //    else
        //    {
        //        lblLoading.Visibility = Visibility.Hidden;
        //        lblForgetPw.Visibility = Visibility.Visible;
        //        lblForgetPw.Content = "Forgot Password ?";
        //        tbxUsername.IsEnabled = true;
        //        tbxUsername.BorderBrush = Brushes.Red;
        //        tbxPassword.IsEnabled = true;
        //        tbxPassword.BorderBrush = Brushes.Red;
        //        btnLogin.IsEnabled = true;
        //        Mouse.OverrideCursor = null;
        //    }
        //}
        ////Method to create the cursor loading icon symbol
        //private void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    Thread.Sleep(1000);
        //}
        ////Method to complete the Login Stage, run the loading cursor, provide success message
        //private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if ((e.Cancelled == true))//provide the Forget Password label ONLY!!!
        //    {
        //        lblForgetPw.Visibility = Visibility.Visible;
        //        lblForgetPw.Content = "Canceled!";
        //    }

        //    else if (!(e.Error == null))//provide Forget Password Error Message (Label)
        //    {
        //        lblForgetPw.Visibility = Visibility.Visible;
        //        lblForgetPw.Content = "Error: " + e.Error.Message;
        //    }
        //    else//proceed with the successfull login procedure
        //    {
        //        lblLoading.Visibility = Visibility.Hidden;//hide this
        //        lblForgetPw.Visibility = Visibility.Visible;//show this
        //        lblForgetPw.Content = "LOGIN SUCCESSFUL";//place in ForgetPassword label instead!
        //        Mouse.OverrideCursor = null;
        //        tbxUsername.IsEnabled = true;
        //        tbxPassword.IsEnabled = true;
        //        btnLogin.IsEnabled = true;
        //        //display the Next Window of the GymSystem
        //        this.Hide();
        //        MainWindow mw = new MainWindow();
        //        mw.Show();

        //    }
        //}

        ////private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        ////{

        ////}

    }
}

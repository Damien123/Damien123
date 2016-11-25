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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;

using System.Threading;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace GymSystem
{
    /// <summary>
    /// Interaction logic for UCaddStaff.xaml
    /// </summary>
    public partial class UCaddStaff : UserControl
    {

        List<Staff> staffList = new List<Staff>();
        gymDatabaseEntities dbEntities = new gymDatabaseEntities();
        Staff currentUser = new Staff();
        string entityState = "Modify";


        public UCaddStaff()
        {
            try
            {
                InitializeComponent();
                mtdPopulateUserTable();
                lstUsersList.ItemsSource = staffList;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem during initialisation of application");
            }
        }

        private void mtdPopulateUserTable()
        {
            staffList.Clear();
            foreach (var user in dbEntities.Staffs)
            {
                staffList.Add(user);
            }
        }


        private void lstUsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (staffList.Count > 0)//Make sure a user record exists in the database
            {
                if (lstUsersList.SelectedIndex > -1)//ensures a record is selected
                {
                    //Gets the user from the userList at the same position it is in within the ListView
                    currentUser = staffList.ElementAt(this.lstUsersList.SelectedIndex);
                    mtdPopulateUserDetails(currentUser);
                }
            }
        }

        private void mtdPopulateUserDetails(Staff selectedUser)
        {
            try
            {
                // dockUserPanel.Visibility = Visibility.Visible;
                tbxUserForename.Text = selectedUser.Forename;
                tbxUserSurname.Text = selectedUser.Surname;
                tbxUserPassword.Text = selectedUser.Password;
                tbxUsername.Text = selectedUser.UserName;
                if (selectedUser.AccessLevel == 0)//Admin
                {
                    cboAccessLevel.SelectedIndex = 0;
                }
                if (selectedUser.AccessLevel == 1)//A new record may need to be created and its index will =0
                {
                    cboAccessLevel.SelectedIndex = 1;//Staff
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem importing user information");
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            currentUser.Forename = tbxUserForename.Text.Trim();
            currentUser.Surname = tbxUserSurname.Text.Trim();
            currentUser.Password = tbxUserPassword.Text.Trim();
            currentUser.UserName = tbxUsername.Text.Trim();
            currentUser.AccessLevel = cboAccessLevel.SelectedIndex;
            bool userVerified = mtdVerifyUserDetails(currentUser);
            if (userVerified)
            {
                mtdUpdateUser(currentUser, entityState);
                mtdPopulateUserTable();
                lstUsersList.Items.Refresh();
            }

        }

        private bool mtdVerifyUserDetails(Staff user)
        {
            bool userVerified = false;
            try
            {
                if (user.Forename == null)
                {
                    user.Forename = "";
                }
                if (user.Surname == null)
                {
                    user.Surname = "";
                }
                if (user.UserName == null)
                {
                    user.UserName = "";
                }
                if (user.Password == null)
                {
                    user.Password = "";
                }
                if (user.AccessLevel == -1)
                {
                    user.AccessLevel = 2;
                }
                if (user.Address1 == null)
                {
                    user.Address1 = "";
                }
                if (user.Address2 == null)
                {
                    user.Address2 = "";
                }
                if (user.DOB == null)
                {
                    DateTime todysDate = DateTime.Now.Date;
                    user.DOB = todysDate;
                }
                if (user.Gender == null)
                {
                    user.Gender = "";
                }
                if (user.Phone == null)
                {
                    user.Phone = "";
                }
                if (user.StaffID == null)
                {
                    user.StaffID = "";
                }

                userVerified = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem verifying user");
            }
            return userVerified;
        }

        private void mtdUpdateUser(Staff user, string modifyState)
        {
            try
            {
                if (modifyState == "Add")
                {
                    user.StaffID = Guid.NewGuid().ToString();//Create new StaffID for database                 
                    dbEntities.Configuration.AutoDetectChangesEnabled = false;
                    dbEntities.Configuration.ValidateOnSaveEnabled = false;
                    dbEntities.Entry(user).State = System.Data.Entity.EntityState.Added;
                    //MessageBox.Show("New user added");
                }
                if (modifyState == "Modify")
                {
                    foreach (var userRecord in dbEntities.Staffs.Where(t => t.StaffID == user.StaffID))
                    {
                        userRecord.Forename = user.Forename;
                        userRecord.Surname = user.Surname;
                        userRecord.UserName = user.UserName;
                        userRecord.Password = user.Password;
                        userRecord.AccessLevel = user.AccessLevel;
                        MessageBox.Show("User modified");
                    }
                }
                if (modifyState == "Delete")
                {
                    dbEntities.Staffs.RemoveRange(
                 dbEntities.Staffs.Where(t => t.StaffID == user.StaffID));
                    MessageBox.Show("User deleted");
                }
                dbEntities.SaveChanges();
                dbEntities.Configuration.AutoDetectChangesEnabled = true;
                dbEntities.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem writing to database");
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mtdClearUserDetails();
            entityState = "Add";
           // mtdVerifyUserDetails
            //Tester

            mtdUpdateUser(currentUser, entityState);
            mtdPopulateUserTable();
            lstUsersList.Items.Refresh();

        }
        private void mtdClearUserDetails()
        {
            tbxUserForename.Text = "";
            tbxUserSurname.Text = "";
            tbxUsername.Text = "";
            tbxUserPassword.Text = "";
            cboAccessLevel.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            entityState = "Delete";
            mtdUpdateUser(currentUser, entityState);
            mtdPopulateUserTable();
            lstUsersList.Items.Refresh();

        }


    }
}
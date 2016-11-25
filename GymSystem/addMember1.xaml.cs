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

using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace GymSystem
{
    /// <summary>
    /// Interaction logic for addMember1.xaml
    /// </summary>
    public partial class addMember1 : UserControl
    {

        public addMember1()
        {
            InitializeComponent();
        }

        public static bool Visible { get; internal set; }

      
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<Staff> users = new ObservableCollection<Staff>();
            //users.Add(new Staff { Forename = "firstname-1", Surname = "lastname-1" });
            ////users.Add(new User { FirstName = "firstname-2", LastName = "lastname-2" });
            ////users.Add(new User { FirstName = "firstname-3", LastName = "lastname-3" });
            ////users.Add(new User { FirstName = "firstname-4", LastName = "lastname-4" });
            //DataGrid.ItemsSource = users;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

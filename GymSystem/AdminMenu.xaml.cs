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

namespace GymSystem
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public Staff staff = new Staff();
        public AdminMenu()
        {
            InitializeComponent();
            splashScreen sp = new splashScreen();
            canvasPanel.Children.Add(sp);
        }

        private void addStaff_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCaddStaff addStaff = new UCaddStaff();
            canvasPanel.Children.Add(addStaff);
        }

        private void viewStaff_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCeditStaff editStaff = new UCeditStaff();
            canvasPanel.Children.Add(editStaff);
        }

        private void deleteStaff_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCdeleteStaff delStaff = new UCdeleteStaff();
            canvasPanel.Children.Add(delStaff);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            //Environment.Exit(0);

            MembersMenu mm = new MembersMenu();
            mm.Show();
            this.Close();
            //Environment.Exit(0);
        }

        private void viewTT_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCviewTimetable vTT = new UCviewTimetable();
            canvasPanel.Children.Add(vTT);
        }

        private void editTT_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            EditTimetable eTT = new EditTimetable();
            canvasPanel.Children.Add(eTT);
        }

    }
}

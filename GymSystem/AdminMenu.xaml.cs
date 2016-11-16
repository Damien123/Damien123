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
        public AdminMenu()
        {
            InitializeComponent();
            splashScreen sp = new splashScreen();
            canvasPanel.Children.Add(sp);
        }

        private void addMember_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCaddStaff addStaff = new UCaddStaff();
            canvasPanel.Children.Add(addStaff);
        }

        private void viewMember_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCeditStaff editStaff = new UCeditStaff();
            canvasPanel.Children.Add(editStaff);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCdeleteStaff delStaff = new UCdeleteStaff();
            canvasPanel.Children.Add(delStaff);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}

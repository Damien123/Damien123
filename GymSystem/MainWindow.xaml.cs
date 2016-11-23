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

namespace GymSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Staff staff = new Staff();

        public MainWindow()
        {
            InitializeComponent();
           // canvasPanel.Children.Clear();
            splashScreen sp = new splashScreen();
            lblUserName.Content = staff.UserName;//.ToString();//"Forgot Password ?";
            canvasPanel.Children.Add(sp);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            addMember1 addMem = new addMember1();
            canvasPanel.Children.Add(addMem);
           
            {
               // //deleteMember2.Visible = true; addMember1.Visible = true;
               // deleteMember2 deleteMember = new deleteMember2();
               // deleteMember.Show();
               //// this.Close();
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            deleteMember2 delmem = new deleteMember2();
            canvasPanel.Children.Add(delmem);

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
        //    Window1 win1 = new Window1();
            
        //    canvasPanel = setVisible(true);
        //    canvasPanel.Show(win1);
        }

       

        private void addMember_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            addMember1 addMem = new addMember1();
            canvasPanel.Children.Add(addMem);
        }

        private void viewMember_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            UCviewMem viewMem = new UCviewMem();
            canvasPanel.Children.Add(viewMem);
        }

       

        //private void deleteMemeber_Click(object sender, RoutedEventArgs e)
        //{
        //    canvasPanel.Children.Clear();
        //   deleteMember2 delMem = new deleteMember2();
        //    canvasPanel.Children.Add(delMem);
        //}

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu am = new AdminMenu();
            am.Show();
            this.Close();
            //Environment.Exit(0);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            canvasPanel.Children.Clear();
            deleteMember2 delMem = new deleteMember2();
            canvasPanel.Children.Add(delMem);
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

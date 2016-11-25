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



using System.Media;

namespace GymSystem
{
    /// <summary>
    /// Interaction logic for UCbmi.xaml
    /// </summary>
    public partial class UCbmi : UserControl
    {
        public UCbmi()
        {
            InitializeComponent();
           
        }

        private void btnBMI_KeyDown(object sender, KeyEventArgs e)
        {
           
        }



        private void btnBmi_Click(object sender, RoutedEventArgs e)
        {

            var weight = Convert.ToDecimal(tbxWeight.Text);
            var height = Convert.ToDecimal(tbxHeight.Text);

            var bmi = weight / (height * height);
            var bmi1 = String.Format("{0:0.00}", bmi);
            textBlock.Text = bmi1;

            string Text = Console.ReadLine();
                       
                try
            {
                ////if ((e.KeyChar == '.') && (((TextBox)sender).Text.IndexOf('.') > -1))
                ////{
                ////    e.Handled = true;
                ////    return;
                ////}

                ////if (!Char.IsDigit(e.KeyChar))
                ////{
                ////    if ((e.KeyChar != '.') &&
                ////        (e.KeyChar != Convert.ToChar(Keys.Back)))
                ////    {
                ////        e.Handled = true;
                ////        return;
                ////    }
                ////}
               
               
                if (bmi < 18)
            {
                textBlock.Background = Brushes.LightSkyBlue;
                textBlock.Text = bmi1 + " Your BMI Results Suggest That You Are UnderWeight";
                Console.WriteLine("UnderWeight");
                Console.ReadLine();
                tbxWeight.IsEnabled = true;
                tbxWeight.BorderBrush = Brushes.Aqua;
                tbxHeight.IsEnabled = true;
                tbxHeight.BorderBrush = Brushes.Aqua;
                }
            if (bmi > 18 && bmi < 25)
            {
                textBlock.Background = Brushes.LightSteelBlue;
                textBlock.Text  = bmi1 + " Your BMI Results Suggest That You Are At Normal Weight";
                Console.WriteLine("Normal");
                Console.ReadLine();
                    tbxWeight.IsEnabled = true;
                    tbxWeight.BorderBrush = Brushes.Aqua;
                    tbxHeight.IsEnabled = true;
                    tbxHeight.BorderBrush = Brushes.Aqua;
                }
            if (bmi > 25 && bmi < 29)
            {
                textBlock.Background = Brushes.LightSteelBlue;
                textBlock.Text = bmi1 + " Your BMI Results Suggest That You Are OverWeight";
                Console.WriteLine("OverWeight");
                Console.ReadLine();
                    tbxWeight.IsEnabled = true;
                    tbxWeight.BorderBrush = Brushes.Aqua;
                    tbxHeight.IsEnabled = true;
                    tbxHeight.BorderBrush = Brushes.Aqua;
                }
            if (bmi > 29 && bmi < 40)
            {
                textBlock.Background = Brushes.LightSteelBlue;
                textBlock.Text = bmi1 + " Your BMI Results Suggest That You Are Obese";
                Console.WriteLine("Obese");
                Console.ReadLine();
                    tbxWeight.IsEnabled = true;
                    tbxWeight.BorderBrush = Brushes.Aqua;
                    tbxHeight.IsEnabled = true;
                    tbxHeight.BorderBrush = Brushes.Aqua;
                }
            if (bmi > 40)
            {
                // Console.WriteLine("Extremely Obese");
                // Console.ReadLine();
                textBlock.Background = Brushes.Red;
                textBlock.Text = "Result: " + bmi1 + " Your BMI Suggests That You Are Extremely Obese, Lay Off The Pies!!!";
                    tbxWeight.IsEnabled = true;
                    tbxWeight.BorderBrush = Brushes.Aqua;
                    tbxHeight.IsEnabled = true;
                    tbxHeight.BorderBrush = Brushes.Aqua;
                    // textBlock.WriteLine("Extremely Obese");

                }
            else if (tbxWeight.Text != Text && tbxHeight.Text != Text)
            {             
                tbxWeight.IsEnabled = true;
                tbxWeight.BorderBrush = Brushes.ForestGreen;
                tbxHeight.IsEnabled = true;
                tbxHeight.BorderBrush = Brushes.ForestGreen;
                btnBMI.IsEnabled = true;
                Mouse.OverrideCursor = null;
                MessageBox.Show("else if ..............test!");
                tbxWeight.Clear();
                tbxHeight.Clear();
            }
            else 
            {
                tbxWeight.IsEnabled = true;
                tbxWeight.BorderBrush = Brushes.Red;

                tbxHeight.IsEnabled = true;
                tbxHeight.BorderBrush = Brushes.Red;
                btnBMI.IsEnabled = true;
                Mouse.OverrideCursor = null;
                MessageBox.Show("else ..................test.......Please enter the correct Weight and Height E.G (Weight 70 Height 1.8)!");
                tbxWeight.Clear();
                tbxHeight.Clear();
            }
            }
            catch (Exception)
            {
                var exception = new Exception("Catch message: ");
                tbxWeight.IsEnabled = true;
                tbxWeight.BorderBrush = Brushes.Red;
                tbxHeight.IsEnabled = true;
                tbxHeight.BorderBrush = Brushes.Red;
                btnBMI.IsEnabled = true;
                Mouse.OverrideCursor = null;
                MessageBox.Show("CAtch exception ..................test ...........Please enter the correct Weight and Height E.G (Weight 70 Height 1.8)!");
                tbxWeight.Clear();
                tbxHeight.Clear();
                throw;
            }
        }

        
    }
 }


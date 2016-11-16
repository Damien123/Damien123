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
    /// Interaction logic for UCbmi.xaml
    /// </summary>
    public partial class UCbmi : UserControl
    {
        public UCbmi()
        {
            InitializeComponent();
        }

        private void btnBmi_Click(object sender, RoutedEventArgs e)
        {

            var weight = Convert.ToDecimal(tbxWeight.Text);
            var height = Convert.ToDecimal(tbxHeight.Text);

            var bmi = weight / (height * height);
            var bmi1 = String.Format("{0:0.00}", bmi);
            textBlock.Text = bmi1;

            string Text = Console.ReadLine();
            if (bmi < 18)
            {
                textBlock.Text = bmi1 + " Your BMI Results Suggest That Uou Are UnderWeight";
                Console.WriteLine("UnderWeight");
                Console.ReadLine();
            }
            if (bmi > 18 && bmi < 25)
            {
                textBlock.Text = bmi1 + " Your BMI Results Suggest That You Are At Normal Weight";
                Console.WriteLine("Normal");
                Console.ReadLine();
            }
            if (bmi > 25 && bmi < 29)
            {
                textBlock.Text = bmi1 + " Your BMI Results Suggest That You Are OverWeight";
                Console.WriteLine("OverWeight");
                Console.ReadLine();
            }
            if (bmi > 29 && bmi < 40)
            {
                textBlock.Text = bmi1 + " Your BMI Results Suggest That You Are Obese";
                Console.WriteLine("Obese");
                Console.ReadLine();
            }
            if (bmi > 40)
            {
                // Console.WriteLine("Extremely Obese");
                // Console.ReadLine();
                textBlock.Text = "Result: " + bmi1 + " Your BMI Suggests That You Are Extremely Obese, Lay Off The Pies!!!";
                // textBlock.WriteLine("Extremely Obese");

            }
        }
    }
 }


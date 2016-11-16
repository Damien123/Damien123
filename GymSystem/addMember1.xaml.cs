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
    /// Interaction logic for addMember1.xaml
    /// </summary>
    public partial class addMember1 : UserControl
    {

        public addMember1()
        {
            InitializeComponent();
        }

        public static bool Visible { get; internal set; }
    }
}

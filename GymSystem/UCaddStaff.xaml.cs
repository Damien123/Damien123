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
        public UCaddStaff()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection con = new SqlConnection"Data Source=LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Damien\Source\Repos\Damien123\GymSystem\gymDatabase.mdf;Integrated Security=True")
            //sqlCommand sc = new sqlCommand("insert into Staff values('" + tbxID1 + "'," + tbxGender + "'," + tbxFN1 + "'," + tbxSN1 + "'," + tbxDOB + "'," + tbxUN + "'," + tbxAddr1 + "'," + tbxAddr2 + "'," + tbxPW + "'," + tbxPhone + "'," + tbxAL);
            //int o = sc.ExecuteNenQuery();
            //MessageBox.Show(o + " :Record has been inserted");
            //con.Close();



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ////    List<Staff> staffList = new List<Staff>();

            ////    DataTable dt = new DataTable();

            ////    //SqlConnection connection = new SqlConnection("");
            ////    //connection.Open();
            ////    SqlCommand sqlCmd = new SqlCommand("SELECT ForetName,Surname FROM staffList WHERE Forename = Damien AND Surname = Dolan", conn);
            ////    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

            ////  //  sqlCmd.Parameters.AddWithValue("@Value1", tbxFN.SelectedItem.Text);
            ////  //  sqlCmd.Parameters.AddWithValue("@Value2", DropDownList2.SelectedItem.Text);
            ////    sqlDa.Fill(dt);
            ////    if (dt.Rows.Count > 0)
            ////    {
            ////        tbxFN1.Text = dt.Rows[0]["Damien"].ToString();
            ////        //Where ColumnName is the Field from the DB that you want to display
            ////        tbxSN1.Text = dt.Rows[0]["Dolan"].ToString();
            ////    }
            ////   // connection.Close();
            ////}
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Hostel
{
   /// <summary>
   /// Interaction logic for RegistrationWindow.xaml
   /// </summary>
   public partial class RegistrationWindow:Window
   {
      public string nowlogin { get; set; }
      public string nowPasword { get; set; }
      public bool Changeaccount { get; set; } = false;

      string conStr = @" Data Source = DESKTOP-AIOOLC8\MSSQLSERV16JOHN; Initial Catalog=Account; Integrated Security=True;";

      public RegistrationWindow( )
      {
         InitializeComponent( );
      }

      private void Reg_Butt_Click(object sender,RoutedEventArgs e)
      {
         if(Password_text.Password != RPassword_text.Password)
         {
            MessageBox.Show("Passwords don`t match");
         }
         else if(Password_text.Password.Length < 2)
         {
            MessageBox.Show("Password must be longer than 2 characters");
         }
         else if (Reapet_Login())
         {
            MessageBox.Show("A user already exists. Please enter enother login");
         }
         else
         {
            using(SqlConnection con = new SqlConnection(conStr))
            {
               try
               {
                  string sql = string.Format("INSERT Into Accounts (Login, Password,AdminRoot) VALUES ('{0}','{1}','0')", Login_text.Text, Password_text.Password);
                  SqlCommand cmd = new SqlCommand(sql, con);
                  cmd.CommandType = CommandType.Text;
                  con.Open( );
                  cmd.ExecuteNonQuery( );
                  con.Close( );
                  MessageBox.Show("Registration Comleted");
                  Changeaccount = true;
                  nowlogin = Login_text.Text;
                  nowPasword = Password_text.Password;

                  Close( );
               }
               catch(Exception ex)
               {
                  MessageBox.Show(ex.Message);
               }
            }
         }
      }

      public bool Reapet_Login ()
      {
         using(SqlConnection connectDb = new SqlConnection(conStr))
         {
            SqlDataAdapter sda = new SqlDataAdapter ("Select Count (*) From Accounts where Login = '" + Login_text.Text + "'",connectDb );
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return (dt.Rows[0][0].ToString( ) == "1") ? true : false;
         }
      }

      private void Cancel_Butt_Click(object sender,RoutedEventArgs e)
      {
         Changeaccount = false;
         Close( );
      }
   }
}

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
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using Hostel.Properties;

namespace Hostel
{
   /// <summary>
   /// Interaction logic for LoginWindow.xaml
   /// </summary>   
   public partial class LoginWindow:Window
   {
      public LoginWindow( )
      {
         InitializeComponent( );
         Window_Loaded( );
         Passworder psser = new Passworder();
         this.DataContext = psser;
      }

      private void Cancel_Butt_Click(object sender,RoutedEventArgs e)
      {
         Close( );
      }//Closing Window

      private void Enter_Butt_Click(object sender,RoutedEventArgs e)
      {
         Enter_Event( );
      }

      private void Window_Loaded ()
      {
         if(Settings.Default.Remember)
         {
            Login_text.Text = Settings.Default.Login;
         }
         else
         {
            Login_text.Text = Settings.Default.Login = "";
            Password_text.Password = Settings.Default.Password = "";
         }
      }
      private void Label_Login_MouseDoubleClick(object sender,MouseButtonEventArgs e)
      {
         //Login_text.Text = "admin";
         //Password_text.Password = "admin";
      }//Super Cheet Cod

      private void Registrtion_Butt_Click(object sender,RoutedEventArgs e)
      {
         RegistrationWindow rg = new RegistrationWindow();
         this.Hide( );
         rg.ShowDialog( );
         this.Show( );
         if(rg.Changeaccount)//registered or not
         {
            Login_text.Text = rg.nowlogin;//give registered Login
            Password_text.Password = rg.nowPasword;//give registered Password
         }
      }//registration Window

      private void textBlock_MouseUp(object sender,MouseButtonEventArgs e)
      {
         if(Check_Registered_User("Select Count (*) From Accounts where Login = '" + Login_text.Text + "'"))
         {
            EditingProfile EP = new EditingProfile { NowLogin = Login_text.Text};
            EP.textBlock.Text = "Password recovery For User : " + Login_text.Text;
            EP.ShowDialog( );
            if (EP.NowPass != "")
            {
               Password_text.Password = EP.NowPass;
            }
         }
         else
         {
            MessageBox.Show("Kek!!   You don`t virtual!!");
         }
      }//Forgot password Window

      private bool Check_Registered_User(string s)
      {
         try
         {
            string conStr = @" Data Source = DESKTOP-AIOOLC8\MSSQLSERV16JOHN; Initial Catalog=Account; Integrated Security=True;";
            using(SqlConnection connectDb = new SqlConnection(conStr))
            {
               //Data Source=DESKTOP-EBHRT5L; Initial Catalog=Users; Integrated Security=True;");     DESKTOP-AIOOLC8\MSSQLSERV16JOHN
               SqlDataAdapter sda = new SqlDataAdapter (s,connectDb );
               DataTable dt = new DataTable();
               sda.Fill(dt);
               if(dt.Rows[0][0].ToString( ) == "1")
                  return true;
               else
                  return false;
            }
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
         return false;
      }

      private void Window_KeyDown(object sender,KeyEventArgs e)
      {
         if(e.Key == Key.Enter)
            Enter_Event( );
      }
      private void Window_KeyEscDown(object sender,KeyEventArgs e)
      {
         if(e.Key == Key.Escape)
            Close( );
      }

      private void Enter_Event( )
      {
         if(Check_Registered_User("Select Count (*) From Accounts where Login = '" + Login_text.Text + "' and Password = '" + Password_text.Password + "'"))
         {
            MessageBox.Show("Done");
            this.Hide( );
            MainForm mainform = new MainForm();
            mainform.UserLoginName_2.Content = Login_text.Text;
            mainform.ShowDialog( );
            if(mainform.allexit)
               Close( );
            else
            {
               Window_Loaded( );
               this.Show( );
            }
         }
         else
            MessageBox.Show("Not correct data, please check Login and password");
      }

      private void Window_Closing(object sender,System.ComponentModel.CancelEventArgs e)
      {
         if(MessageBox.Show("Do you really want to close the program?","Closing",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.No)
            e.Cancel = true;              
      }
   }
}
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
//Password recovery For User :
namespace Hostel
{
   /// <summary>
   /// Interaction logic for EditingProfile.xaml
   /// </summary>
   public partial class EditingProfile:Window
   {
      public string NowLogin { get; set; }
      public EditingProfile( )
      {
         InitializeComponent( );
      }

      private void Cancel_Butt_Click(object sender,RoutedEventArgs e)
      {
         Close( );
      }

      private void Enter_Butt_Click(object sender,RoutedEventArgs e)
      {
         try
         {
            if(RPass_TextBox.Text != Pass_TextBox.Text)
            {
               MessageBox.Show("Passwords do not coincide!");
            }
            else if(MessageBox.Show("Are you really " + NowLogin,"",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
               MessageBox.Show("Okay, I Believe You");
               if(MessageBox.Show("Are you seriously?? ","",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
               {
                  string conStr = @" Data Source = DESKTOP-AIOOLC8\MSSQLSERV16JOHN; Initial Catalog=Account; Integrated Security=True;";
                  using(SqlConnection connectDb = new SqlConnection(conStr))
                  {
                     string sql = "UPDATE Accounts SET Password = '" + Pass_TextBox.Text+"' WHERE Login = '"+NowLogin+"';" ;
                     SqlCommand cmd = new SqlCommand(sql, connectDb);
                     cmd.CommandType = CommandType.Text;
                     connectDb.Open( );
                     cmd.ExecuteNonQuery( );
                     connectDb.Close( );
                  }
               }
            }
            else
            {
               MessageBox.Show("HA!! I know this");
            }
         }
         catch(Exception exception)
         {

            MessageBox.Show(exception.Message);
         }
         Close( );
      }
   }
}


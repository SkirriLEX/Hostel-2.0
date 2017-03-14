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

namespace Hostel
{
   /// <summary>
   /// Interaction logic for MainForm.xaml
   /// </summary>
   public partial class MainForm:Window
   {
      public bool allexit { get; set; } = true;//exit flag for allexit
     
      public MainForm( )
      {
         InitializeComponent( );
      }

      private void MI_Changeuser_Click(object sender,RoutedEventArgs e)//when we exit account
      {
         allexit = false;//exit flag
         Close( );
      }

      private void MI_Exit_Click(object sender,RoutedEventArgs e)//when we close program
      {
         Close( );
      }

      private void Load_database_Click(object sender,RoutedEventArgs e)
      {
         
      }
   }
}

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
      public bool Dataconection { get; set; } = false;
     
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

      private void QueryDb_Click(object sender,RoutedEventArgs e)
      {
         if(Dataconection)
         {
            QerrySelectorWindow qw = new QerrySelectorWindow();
            qw.ShowDialog( );
         }
         else
         {
            MessageBox.Show("Please. Conected Database","Database not conected",MessageBoxButton.OK,MessageBoxImage.Hand);
         }
      }
   }
}

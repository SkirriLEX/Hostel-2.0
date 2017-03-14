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
using System.Windows.Threading;

namespace Hostel
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow:Window
   {
      private  DispatcherTimer Timer;
      public MainWindow( )
      {
         InitializeComponent( );
         Timer = new DispatcherTimer( );
         Timer.Tick += new EventHandler(Timer_Tick);
         Timer.Interval = new TimeSpan(0,0,4);
         Timer.Start( );
      }
      private void Timer_Tick(object sender,EventArgs e)
      {
         go( );
      }

      private void Window_MouseDoubleClick(object sender,MouseButtonEventArgs e)
      {
         go( );
      }
      private void go ()
      {
         Timer.Stop( );
         this.Hide( );
         LoginWindow loadWindow = new LoginWindow();
         loadWindow.ShowDialog( );
         this.Close( );
      }
   }
}

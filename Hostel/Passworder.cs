using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.Properties;

namespace Hostel
{
   class Passworder
   {

      public bool SetRem
      {
         get
         {
            return Settings.Default.Remember;
         }
         set
         {
            Settings.Default.Remember = value;
            Settings.Default.Save( );
         }
      }

      public string Setlog
      {
         get
         {
            return Settings.Default.Login;
         }
         set
         {
            Settings.Default.Login = value;
            Settings.Default.Save( );
         }
      }      
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POCA.Control_Layer
{

    class UserController
    {
        
        public UserController()
        {
        }

        public void CreateUser()
        {
             
          //  webs.BeginStartService(Callback, null);
          //  webs.BeginCreateUser(new User("a","b","c","d","e"), Callback, null);
            
        }

        public void Callback(IAsyncResult r)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() => {
               
            });

        }

    }
}

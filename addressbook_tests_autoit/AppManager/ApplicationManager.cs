using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private AutoItX3 aux;
        private GroupHelper groupHelper;
        public static string WINTITLE = "Free Address Book";

        public ApplicationManager()
        {
            RunApp(@"C:\test\AddressBook.exe");
            groupHelper = new GroupHelper(this);
        }

        private void RunApp(string v)
        {
            aux = new AutoItX3();
            aux.Run(v, "", aux.SW_SHOWNORMAL);
            aux.WinWait(WINTITLE);
            aux.WinSetState(WINTITLE, "", aux.SW_SHOW);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux { get { return aux; } }
        public GroupHelper Groups { get { return groupHelper; }  }
    }
}

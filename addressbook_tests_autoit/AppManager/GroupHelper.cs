using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper (ApplicationManager manager) : base(manager) { }
        public static string GROUPWINTITLE = "Group editor";
        public List<GroupData> GetGroupsList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i, "");
                list.Add(new GroupData() { Name = item });
            }
            CloseGroupsDialog();
            return list;
        }

        internal void Remove(int toBeRemoved)
        {
            OpenGroupsDialog();
            SelectGroup(toBeRemoved);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.Send("{ENTER}");
            CloseGroupsDialog();
        }

        private void SelectGroup(int toBeRemoved)
        {
            //aux.ControlTreeView(GROUPWINTITLE, "", String.Format("[WindowsForms10.SysTreeView32.app.0.2c908d51; INSTANCE:{0}]", toBeRemoved), "Check", "", "");
            //aux.ControlTreeView(GROUPWINTITLE, "", "[WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", toBeRemoved, "");
            for (int i = 0; i < toBeRemoved; i++)
            {
                aux.Send("{DOWN}");
            }
        }

        public void Add(GroupData newData)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newData.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();
        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}
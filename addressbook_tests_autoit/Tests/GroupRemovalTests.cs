using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests :TestBase
    {
        [Test]
        public void TestGroupRemovalByNumber()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            int toBeRemoved = 2;
            app.Groups.Remove(toBeRemoved);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(toBeRemoved-1);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

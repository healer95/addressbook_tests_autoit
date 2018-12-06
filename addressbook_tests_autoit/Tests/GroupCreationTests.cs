using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            GroupData newData = new GroupData() { Name = "test1" };
            app.Groups.Add(newData);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(newData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

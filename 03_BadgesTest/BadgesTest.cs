using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_BadgesTest
{
    [TestClass]
    public class BadgesTest
    {
        [TestMethod]
        public void TestAddingBadge_ShouldReturnCorrectBoolean()
        {
            Badge badge = new Badge();
            BadgesRepository repository = new BadgesRepository();

            bool success = repository.AddBadgeToDictionary(badge);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestingAddingDoorToBadge_ShouldReturnCorrectBoolean()
        {
            Badge badge = new Badge();
            string door = "door";

            badge.ListOfDoors.Add(door);

            bool success = badge.ListOfDoors.Contains(door);

            Assert.IsTrue(success);
        }


        [TestMethod]
        public void FindBadgeByKey_ShouldFindCorrectBadgeName()
        {
            Badge badge = new Badge();
            BadgesRepository repo = new BadgesRepository();
            badge.BadgeID = 1;
            repo.AddBadgeToDictionary(badge);

            repo.FindBadgeByKey(1);

            Assert.AreEqual(badge, repo.FindBadgeByKey(1));
        }


        [TestMethod]
        public void DeleteDoorFromBadge()
        {
            Badge badge = new Badge();
            string door = "door";

            badge.ListOfDoors.Add(door);

            badge.ListOfDoors.Contains(door);

            bool success = badge.ListOfDoors.Remove(door);

            Assert.IsTrue(success);
        }
    }
}

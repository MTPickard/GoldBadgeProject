using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_CafeTest
{
    [TestClass]
    public class CafeTests
    {

        CafeMenuRepository _menuItems = new CafeMenuRepository();


        [TestMethod]
        public void AddingItemsToMenu_ShouldReturnCorrectBoolean()
        {
            Menu item = new Menu();
            CafeMenuRepository repo = new CafeMenuRepository();

            bool success = repo.AddItemToMenu(item);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetMenuDirectory_ShouldReturnCorrectList()
        {
            Menu item = new Menu();
            CafeMenuRepository repo = new CafeMenuRepository();

            repo.AddItemToMenu(item);

            List<Menu> menuList = repo.DisplayMenuItems();

            bool success = menuList.Contains(item);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void DeleteItemFromMenu_ShouldReturnCorrectBoolean()
        {
            Menu firstTest = new Menu();
            _menuItems.AddItemToMenu(firstTest);

            List<Menu> itemList = _menuItems.DisplayMenuItems();

            itemList.Contains(firstTest);

            bool removeItem = _menuItems.DeleteItemFromMenu(firstTest);

            Assert.IsTrue(removeItem);
        }
    }
}

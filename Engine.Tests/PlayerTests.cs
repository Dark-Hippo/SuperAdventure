using Engine;
using Engine.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private readonly Player _player;
        private readonly Quest _quest1;
        private readonly IItem _weapon1;
        private readonly IItem _item1;

        public PlayerTests()
        {
            _player = new Player(0, 10, 1, 0, 1);
            _quest1 = new Quest(1, "test", "desc", 1, 1);
            _weapon1 = new Weapon(1, "Weapon 1", "Weapons", 0, 10);
            _item1 = new Item(2, "Item 1", "Items");
        }

        [TestMethod]
        public void CanMarkQuestComplete()
        {
            _player.Quests.Add(new PlayerQuest(_quest1));
            _player.MarkQuestCompleted(_quest1);
            Assert.IsTrue(_player.Quests[0].IsCompleted);            
        }

        [TestMethod]
        public void CanAddNewItemToEmptyInventory()
        {
            _player.AddItemToInventory(_weapon1);
            Assert.AreEqual(_weapon1, _player.Inventory[0].Details);
        }

        [TestMethod]
        public void CanAddMultipleItemsToInventory()
        {
            _player.AddItemToInventory(_weapon1);
            _player.AddItemToInventory(_item1);
            Assert.AreEqual(2, _player.Inventory.Count);
        }

        [TestMethod]
        public void CanAddExistingItemToInventory()
        {
            _player.AddItemToInventory(_weapon1);
            _player.AddItemToInventory(_weapon1);
            Assert.AreEqual(2, _player.Inventory[0].Quantity);
        }
    }
}

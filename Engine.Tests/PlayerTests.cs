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

        public PlayerTests()
        {
            _player = new Player(0, 10, 1, 0, 1);
            _quest1 = new Quest(1, "test", "desc", 1, 1);
            _weapon1 = new Weapon(1, "Weapon 1", "Weapons", 0, 10);
        }

        [TestMethod]
        public void CanMarkQuestComplete()
        {
            _player.Quests.Add(new PlayerQuest(_quest1));
            _player.MarkQuestCompleted(_quest1);
            Assert.IsTrue(_player.Quests[0].IsCompleted);            
        }

        [TestMethod]
        public void CanAddItemToInventory()
        {
            var _inventoryItem = new InventoryItem(_weapon1, 1);
            _player.Inventory.Add(_inventoryItem);
            CollectionAssert.Contains(_player.Inventory, _inventoryItem);
        }
    }
}

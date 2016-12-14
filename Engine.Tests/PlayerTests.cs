using Engine;
using Engine.Interfaces;
using Engine.Models;
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
        private readonly QuestCompletionItem _questCompletionWeapon;
        private readonly QuestCompletionItem _questCompletionItem;

        public PlayerTests()
        {
            _player = new Player(0, 10, 1, 0, 1);
            _quest1 = new Quest(1, "test", "desc", 1, 1);
            _weapon1 = new Weapon(1, "Weapon 1", "Weapons", 0, 10);
            _item1 = new Item(2, "Item 1", "Items");
            _questCompletionWeapon = new QuestCompletionItem(_weapon1, 1);
            _questCompletionItem = new QuestCompletionItem(_item1, 1);
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

        [TestMethod]
        public void CanRemoveSingleQuestCompletionItem()
        {
            var inventoryItem = new InventoryItem(_weapon1, 1);
            _quest1.QuestCompletionItems.Add(_questCompletionWeapon);
            _player.Inventory.Add(inventoryItem);
            _player.RemoveQuestCompletionItems(_quest1);

            Assert.AreEqual(0, _player.Inventory[0].Quantity);
        }

        [TestMethod]
        public void CanRemoveMultipleUniqueQuestCompletionItems()
        {
            var inventoryItem1 = new InventoryItem(_weapon1, 1);
            var inventoryItem2 = new InventoryItem(_item1, 1);
            _quest1.QuestCompletionItems.Add(_questCompletionItem);
            _quest1.QuestCompletionItems.Add(_questCompletionWeapon);
            _player.Inventory.Add(inventoryItem1);
            _player.Inventory.Add(inventoryItem2);

            _player.RemoveQuestCompletionItems(_quest1);

            Assert.AreEqual(0, _player.Inventory[0].Quantity);
            Assert.AreEqual(0, _player.Inventory[1].Quantity);
        }

        [TestMethod]
        public void CanRemoveMultipleIdenticalQuestCompletionItems()
        {
            var inventoryItem = new InventoryItem(_item1, 3);
            var questCompletionItems = new QuestCompletionItem(_item1, 3);

            _quest1.QuestCompletionItems.Add(questCompletionItems);
            _player.Inventory.Add(inventoryItem);

            _player.RemoveQuestCompletionItems(_quest1);

            Assert.AreEqual(0, _player.Inventory[0].Quantity);
        }
    }
}

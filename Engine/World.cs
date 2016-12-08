using Engine.Interfaces;
using Engine.Consts;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public static class World
    {
        public static List<IItem> Items { get; set; } = new List<IItem>();
        public static List<Monster> Monsters { get; set; } = new List<Monster>();
        public static List<Quest> Quests { get; set; } = new List<Quest>();
        public static List<Location> Locations { get; set; } = new List<Location>();
                

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEMS.RUSTY_SWORD, "Rusty sword", "Rusty swords", 0, 5));
            Items.Add(new Item(ITEMS.RAT_TAIL, "Rat tail", "Rat tails"));
            Items.Add(new Item(ITEMS.PIECE_OF_FUR, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(ITEMS.SNAKE_FANG, "Snake fang", "Snake fangs"));
            Items.Add(new Item(ITEMS.SNAKESKIN, "Snakeskin", "Snakeskins"));
            Items.Add(new Weapon(ITEMS.CLUB, "Club", "Clubs", 3, 10));
            Items.Add(new HealingPotion(ITEMS.HEALING_POTION, "Healing potion", "Healing potions", 5));
            Items.Add(new Item(ITEMS.SPIDER_FANG, "Spider fang", "Spider fangs"));
            Items.Add(new Item(ITEMS.SPIDER_SILK, "Spider silk", "Spider silks"));
            Items.Add(new Item(ITEMS.ADVENTURER_PASS, "Adventurer pass", "Adventurer passes"));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTERS.RAT, "Rat", 5, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByID(ITEMS.RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEMS.PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(MONSTERS.SNAKE, "Snake", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID(ITEMS.SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEMS.SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(MONSTERS.GIANT_SPIDER, "Giant spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEMS.SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEMS.SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUESTS.ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEMS.RAT_TAIL), 3));

            clearAlchemistGarden.RewardItem = ItemByID(ITEMS.HEALING_POTION);

            Quest clearFarmersField =
                new Quest(
                    QUESTS.FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEMS.SNAKE_FANG), 3));

            clearFarmersField.RewardItem = ItemByID(ITEMS.ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATIONS.HOME, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LOCATIONS.TOWN_SQUARE, "Town square", "You see a fountain.");

            Location alchemistHut = new Location(LOCATIONS.ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.QuestAvailableHere = QuestByID(QUESTS.ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATIONS.ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTERS.RAT);

            Location farmhouse = new Location(LOCATIONS.FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.QuestAvailableHere = QuestByID(QUESTS.FARMERS_FIELD);

            Location farmersField = new Location(LOCATIONS.FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.MonsterLivingHere = MonsterByID(MONSTERS.SNAKE);

            Location guardPost = new Location(LOCATIONS.GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", ItemByID(ITEMS.ADVENTURER_PASS));

            Location bridge = new Location(LOCATIONS.BRIDGE, "Bridge", "A stone bridge crosses a wide river.");

            Location spiderField = new Location(LOCATIONS.SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.MonsterLivingHere = MonsterByID(MONSTERS.GIANT_SPIDER);

            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static IItem ItemByID(int id)
            => Items.SingleOrDefault(i => i.ID == id);

        public static Monster MonsterByID(int id)
            => Monsters.SingleOrDefault(m => m.ID == id);

        public static Quest QuestByID(int id)
            => Quests.SingleOrDefault(m => m.ID == id);

        public static Location LocationByID(int id) 
            => Locations.SingleOrDefault(l => l.ID == id);
    }
}

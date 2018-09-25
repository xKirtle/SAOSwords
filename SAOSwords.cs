using Terraria.ModLoader;

namespace SAOSwords
{
    class SAOSwords : Mod
    {
        internal static SAOSwords instance;

        public object UI { get; internal set; }
        private UserInterface UserInterface;
        internal UserInterface PersonUserInterface;
        internal UI UI;
        public override void Load()
        {
            instance = this;

            if (!Main.dedServ)
            {
                // Custom UI
                exampleUI = new ExampleUI();
                exampleUI.Activate();
                exampleUserInterface = new UserInterface();
                exampleUserInterface.SetState(exampleUI);

                // UserInterface can only show 1 UIState at a time. If you want different "pages" for a UI, switch between UIStates on the same UserInterface instance. 
                // We want both the Coin counter and the Example Person UI to be independent and coexist simultaneously, so we have them each in their own UserInterface.
                examplePersonUserInterface = new UserInterface();
                // We will call .SetState later in ExamplePerson.OnChatButtonClicked
            }
        }

        const int ShakeLength = 5;
        int ShakeCount = 0;
        float previousRotation = 0;
        float targetRotation = 0;
        float previousOffsetX = 0;
        float previousOffsetY = 0;
        float targetOffsetX = 0;
        float targetOffsetY = 0;

        public override void UpdateUI(GameTime gameTime)
        {
            if (exampleUserInterface != null && ExampleUI.visible)
                exampleUserInterface.Update(gameTime);
            if (examplePersonUserInterface != null)
                examplePersonUserInterface.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Coins Per Minute",
                    delegate
                    {
                        if (ExampleUI.visible)
                        {
                            exampleUserInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int InventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (InventoryIndex != -1)
            {
                layers.Insert(InventoryIndex + 1, new LegacyGameInterfaceLayer(
                    "ExampleMod: Example Person UI",
                    delegate
                    {
                        // If the current UIState of the UserInterface is null, nothing will draw. We don't need to track a separate .visible value.
                        examplePersonUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
        }

        public static bool NoZone(NPCSpawnInfo spawnInfo)
        {
            return NoZoneAllowWater(spawnInfo) && !spawnInfo.water;
        }

        public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
        }

        public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZone(spawnInfo);
        }

        public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);
        }

        public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);
        }
    }

}

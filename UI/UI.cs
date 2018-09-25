﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;
using Terraria.Localization;

namespace SAOSwords.UI
{
    // UIs visibility is toggled by typing "/coin" in chat. (See CoinCommand.cs)
    // UI is a simple UI example showing how to use UIPanel, UIImageButton, and even a custom UIElement.
    class UI : UIState
    {
        public DragableUIPanel coinCounterPanel;
        public UIMoneyDisplay moneyDiplay;
        public static bool visible = false;

        // In OnInitialize, we place various UIElements onto our UIState (this class).
        // UIState classes have width and height equal to the full screen, because of this, usually we first define a UIElement that will act as the container for our UI.
        // We then place various other UIElement onto that container UIElement positioned relative to the container UIElement.
        public override void OnInitialize()
        {
            // Here we define our container UIElement. In DragableUIPanel.cs, you can see that DragableUIPanel is a UIPanel with a couple added features.
            coinCounterPanel = new DragableUIPanel();
            coinCounterPanel.SetPadding(0);
            // We need to place this UIElement in relation to its Parent. Later we will be calling `base.Append(coinCounterPanel);`. 
            // This means that this class, UI, will be our Parent. Since UI is a UIState, the Left and Top are relative to the top left of the screen.
            coinCounterPanel.Left.Set(400f, 0f);
            coinCounterPanel.Top.Set(100f, 0f);
            coinCounterPanel.Width.Set(170f, 0f);
            coinCounterPanel.Height.Set(70f, 0f);
            coinCounterPanel.BackgroundColor = new Color(73, 94, 171);

            // Next, we create another UIElement that we will place. Since we will be calling `coinCounterPanel.Append(playButton);`, Left and Top are relative to the top left of the coinCounterPanel UIElement. 
            // By properly nesting UIElements, we can position things relatively to each other easily.
            Texture2D buttonPlayTexture = ModLoader.GetTexture("Terraria/UI/ButtonPlay");
            UIHoverImageButton playButton = new UIHoverImageButton(buttonPlayTexture, "Reset Coins Per Minute Counter");
            playButton.Left.Set(110, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            // UIHoverImageButton doesn't do anything when Clicked. Here we assign a method that we'd like to be called when the button is clicked.
            playButton.OnClick += new MouseEvent(PlayButtonClicked);
            coinCounterPanel.Append(playButton);

            Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
            UIHoverImageButton closeButton = new UIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52")); // Localized text for "Close"
            closeButton.Left.Set(140, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnClick += new MouseEvent(CloseButtonClicked);
            coinCounterPanel.Append(closeButton);

            // UIMoneyDisplay is a fairly complicated custom UIElement. UIMoneyDisplay handles drawing some text and coin textures.
            // Organization is key to managing UI design. Making a contained UIElement like UIMoneyDisplay will make many things easier.
            moneyDiplay = new UIMoneyDisplay();
            moneyDiplay.Left.Set(15, 0f);
            moneyDiplay.Top.Set(20, 0f);
            moneyDiplay.Width.Set(100f, 0f);
            moneyDiplay.Height.Set(0, 1f);
            coinCounterPanel.Append(moneyDiplay);

            base.Append(coinCounterPanel);

            // As a recap, UI is a UIState, meaning it covers the whole screen. We attach coinCounterPanel to UI some distance from the top left corner.
            // We then place playButton, closeButton, and moneyDiplay onto coinCounterPanel so we can easily place these UIElements relative to coinCounterPanel.
            // Since coinCounterPanel will move, this proper organization will move playButton, closeButton, and moneyDiplay properly when coinCounterPanel moves.
        }

        private void PlayButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(SoundID.MenuOpen);
            moneyDiplay.ResetCoins();
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(SoundID.MenuOpen);
            visible = false;
        }

        public void updateValue(int pickedUp)
        {
            moneyDiplay.coins += pickedUp;
            moneyDiplay.addCPM(pickedUp);
        }
    }

    internal class UIHoverImageButton : UIImageButton
    {
        internal string hoverText;

        public UIHoverImageButton(Texture2D texture, string hoverText) : base(texture)
        {
            this.hoverText = hoverText;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            if (IsMouseHovering)
            {
                Main.hoverItemName = hoverText;
            }
        }
    }

    public class UIMoneyDisplay : UIElement
    {
        public long coins;

        public UIMoneyDisplay()
        {
            Width.Set(100, 0f);
            Height.Set(40, 0f);

            for (int i = 0; i < 60; i++)
            {
                coinBins[i] = -1;
            }
        }

        //DateTime dpsEnd;
        //DateTime dpsStart;
        //int dpsDamage;
        public bool dpsStarted;
        public DateTime dpsLastHit;

        // Array of ints 60 long.
        // "length" = seconds since reset
        // reset on button or 20 seconds of inactivity?
        // pointer to index so on new you can clear previous
        int[] coinBins = new int[60];
        int coinBinsIndex;

        public void addCPM(int coins)
        {
            int second = DateTime.Now.Second;
            if (second != coinBinsIndex)
            {
                coinBinsIndex = second;
                coinBins[coinBinsIndex] = 0;
            }
            coinBins[coinBinsIndex] += coins;
        }

        public int getCPM()
        {
            int second = DateTime.Now.Second;
            if (second != coinBinsIndex)
            {
                coinBinsIndex = second;
                coinBins[coinBinsIndex] = 0;
            }

            long sum = coinBins.Sum(a => a > -1 ? a : 0);
            int count = coinBins.Count(a => a > -1);
            if (count == 0)
            {
                return 0;
            }
            return (int)((sum * 60f) / count);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            Vector2 drawPos = new Vector2(innerDimensions.X + 5f, innerDimensions.Y + 30f);

            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;

            int[] coinsArray = Utils.CoinsSplit(coins);
            for (int j = 0; j < 4; j++)
            {
                int num = (j == 0 && coinsArray[3 - j] > 99) ? -6 : 0;
                spriteBatch.Draw(Main.itemTexture[74 - j], new Vector2(shopx + 11f + (float)(24 * j), shopy /*+ 75f*/), null, Color.White, 0f, Main.itemTexture[74 - j].Size() / 2f, 1f, SpriteEffects.None, 0f);
                Utils.DrawBorderStringFourWay(spriteBatch, Main.fontItemStack, coinsArray[3 - j].ToString(), shopx + (float)(24 * j) + (float)num, shopy/* + 75f*/, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
            }

            coinsArray = Utils.CoinsSplit(getCPM());
            for (int j = 0; j < 4; j++)
            {
                int num = (j == 0 && coinsArray[3 - j] > 99) ? -6 : 0;
                spriteBatch.Draw(Main.itemTexture[74 - j], new Vector2(shopx + 11f + (float)(24 * j), shopy + 25f), null, Color.White, 0f, Main.itemTexture[74 - j].Size() / 2f, 1f, SpriteEffects.None, 0f);
                Utils.DrawBorderStringFourWay(spriteBatch, Main.fontItemStack, coinsArray[3 - j].ToString(), shopx + (float)(24 * j) + (float)num, shopy + 25f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
            }
            Utils.DrawBorderStringFourWay(spriteBatch, /*SAOSwords.exampleFont*/ Main.fontItemStack, "CPM", shopx + (float)(24 * 4), shopy + 25f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
        }

        internal void ResetCoins()
        {
            coins = 0;
            for (int i = 0; i < 60; i++)
            {
                coinBins[i] = -1;
            }
        }
    }

    /*public class MoneyCounterGlobalItem : GlobalItem
    {
        public override bool OnPickup(Item item, Player player)
        {
            if (item.type == ItemID.CopperCoin)
            {
                SAOSwords.instance.UI.updateValue(item.stack);
                // We can cast mod to SAOSwords or just utilize SAOSwords.instance.
                // (mod as SAOSwords).UI.updateValue(item.stack);
            }
            else if (item.type == ItemID.SilverCoin)
            {
                SAOSwords.instance.UI.updateValue(item.stack * 100);
            }
            else if (item.type == ItemID.GoldCoin)
            {
                SAOSwords.instance.UI.updateValue(item.stack * 10000);
            }
            else if (item.type == ItemID.PlatinumCoin)
            {
                SAOSwords.instance.UI.updateValue(item.stack * 1000000);
            }
            return base.OnPickup(item, player);
        }
    }*/
}
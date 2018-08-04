using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;

namespace SAOSwords.UI
{
    class UI : UIState
    {
        public UIPanel Panel;
        public UIMoneyDisplay moneyDiplay;
        public static bool visible = false;

        public override void OnInitialize()
        {
            Panel = new UIPanel();
            Panel.SetPadding(0);
            Panel.Left.Set(400f, 0f);
            Panel.Top.Set(100f, 0f);
            Panel.Width.Set(170f, 0f);
            Panel.Height.Set(70f, 0f);
            Panel.BackgroundColor = new Color(73, 94, 171);

            Panel.OnMouseDown += new UIElement.MouseEvent(DragStart);
            Panel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

            Texture2D buttonPlayTexture = ModLoader.GetTexture("Terraria/UI/ButtonPlay");
            UIImageButton playButton = new UIImageButton(buttonPlayTexture);
            playButton.Left.Set(110, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnClick += new MouseEvent(PlayButtonClicked);
            Panel.Append(playButton);

            Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
            UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
            closeButton.Left.Set(140, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnClick += new MouseEvent(CloseButtonClicked);
            Panel.Append(closeButton);

            moneyDiplay = new UIMoneyDisplay();
            moneyDiplay.Left.Set(15, 0f);
            moneyDiplay.Top.Set(20, 0f);
            moneyDiplay.Width.Set(100f, 0f);
            moneyDiplay.Height.Set(0, 1f);
            Panel.Append(moneyDiplay);

            base.Append(Panel);
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

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - Panel.Left.Pixels, evt.MousePosition.Y - Panel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            Panel.Left.Set(end.X - offset.X, 0f);
            Panel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (Panel.ContainsPoint(MousePosition))
            {
                // Checking ContainsPoint and then setting mouseInterface to true is very common. This causes clicks to not cause the player to use current items. 
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                Panel.Left.Set(MousePosition.X - offset.X, 0f);
                Panel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); // don't remove.

            // Here we check if the Panel is outside the UIState rectangle. (in other words, the whole screen)
            // By doing this and some simple math, we can snap the panel back on screen if the user resizes his window or otherwise changes resolution.
            if (!Panel.GetDimensions().ToRectangle().Intersects(GetDimensions().ToRectangle()))
            {
                var parentSpace = GetDimensions().ToRectangle();
                Panel.Left.Pixels = Utils.Clamp(Panel.Left.Pixels, 0, parentSpace.Right - Panel.Width.Pixels);
                Panel.Top.Pixels = Utils.Clamp(Panel.Top.Pixels, 0, parentSpace.Bottom - Panel.Height.Pixels);
                Panel.Recalculate();
            }
        }

        public void updateValue(int pickedUp)
        {
            moneyDiplay.coins += pickedUp;
            moneyDiplay.addCPM(pickedUp);
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

    public class MoneyCounterGlobalItem : GlobalItem
    {
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using SAOSwords.Items.Weapons.Swords;
using SAOSwords.Items.Quest;

namespace SAOSwords.NPCs.TownNPCs
{
    public class TownNPC : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TownNPC");
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 30;
            npc.height = 48;
            npc.aiStyle = 7;
            npc.defense = 25;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            Main.npcFrameCount[npc.type] = 21;
            NPCID.Sets.ExtraFramesCount[npc.type] = 5;
            NPCID.Sets.AttackFrameCount[npc.type] = 2;
            NPCID.Sets.DangerDetectRange[npc.type] = 150;
            NPCID.Sets.AttackType[npc.type] = 3; //0 (throwing), 1 (shooting), or 2 (magic). 3 (melee) 
            NPCID.Sets.AttackTime[npc.type] = 20;
            NPCID.Sets.AttackAverageChance[npc.type] = 10;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
            animationType = NPCID.Guide;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)    //Allows you to define special conditions required for this town NPC's house
        {
            return true;
        }
        public override string TownNPCName()     //Allows you to give this town NPC any name when it spawns
        {
            switch (WorldGen.genRand.Next(6))
            {
                case 0:
                    return "Atria";
                case 1:
                    return "Mintaka";
                case 2:
                    return "Nashira";
                case 3:
                    return "Rana";
                case 4:
                    return "Talita";
                case 5:
                    return "Zosma";
                default:
                    return "Pleyona";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window. 
        {
            button = "Free Quest";   //this defines the buy button name
            //button2 = "Quest";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool openShop) //Allows you to make something happen whenever a button is clicked on this town NPC's chat window. The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
        {

            if (firstButton)
            {
                openShop = true;   //so when you click on buy button opens the shop
            }
            else
            {
                bool openQuest = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("Anneal"));
            nextSlot++;
            //------------------------------------------------------------------------------------------
            //shop.item[nextSlot].SetDefaults(ItemID.WormholePotion);
            //nextSlot++;
            //if (NPC.downedBoss3)   //this make so when Skeletron is killed the town npc will sell this
            //{
            //    shop.item[nextSlot].SetDefaults(ItemID.BookofSkulls);
            //    nextSlot++;
            //    shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll);
            //    nextSlot++;
            //}
            //shop.item[nextSlot].SetDefaults(ItemID.IronskinPotion);
            //nextSlot++;
            //------------------------------------------------------------------------------------------
        }

        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
        {
            /*int player = Player.nameLen;
            if (player >= 0 && Main.rand.Next(4) == 0)
            {
                return "Greetings " + player + ", today is a beatiful day, isn't it?";
            }*/
            /*int nurseNPC = NPC.FindFirstNPC(NPCID.Nurse);
            if (nurseNPC >= 0 && Main.rand.Next(4) == 0)
            {
                return "Isn't it a beautiful day? I wonder how's " + Main.npc[nurseNPC].GivenName + " today, sigh..";
            }*/
            int wizardNPC = NPC.FindFirstNPC(NPCID.Wizard);   //this make so when this npc is close to Wizard
            if (wizardNPC >= 0 && Main.rand.Next(4) == 0)    //has 1 in 3 chance to show this message
            {
                return "Yes " + Main.npc[wizardNPC].GivenName + " is a wizard, just like Harry!";
            }
            /*int guideNPC = NPC.FindFirstNPC(NPCID.Guide); //this make so when this npc is close to the Guide
            if (guideNPC >= 0 && Main.rand.Next(4) == 0) //has 1 in 3 chance to show this message
            {
                return "Sure you can ask " + Main.npc[guideNPC].GivenName + " how to make an Ironskin potion or you can buy it from me..hehehe.";
            }*/
            switch (Main.rand.Next(2))    //this are the messages when you talk to the npc
            {
                case 0:
                    return "What do you want?";
                case 1:
                    return "Would you do me a favor? I have a Quest for you.";
                default:
                    return "Go kill Skeletron.";

            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)//  Allows you to determine the damage and knockback of this town NPC attack
        {
            damage = 20;  //npc damage
            knockback = 2f;   //npc knockback
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)  //Allows you to determine the cooldown between each of this town NPC's attack. The cooldown will be a number greater than or equal to the first parameter, and less then the sum of the two parameters.
        {
            cooldown = 2;
            randExtraCooldown = 10;
        }
        //------------------------------------This is an example of how to make the npc use a sward attack-------------------------------
        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 1f;
            item = Main.itemTexture[mod.ItemType("Liberator")]; //this defines the item that this npc will use
            itemSize = 45;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 45;
            itemHeight = 41;
        }

        //----------------------------------This is an example of how to make the npc use a gun and a projectile ----------------------------------
        /*public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
          {
              scale = 1f;
              item = mod.ItemType("GunName");  
              closeness = 20;
          }
          public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
          {
              projType = ProjectileID.CrystalBullet;
              attackDelay = 1;
          }

          public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
          {
              multiplier = 7f;
             // randomOffset = 4f;

          }   */

    }
}
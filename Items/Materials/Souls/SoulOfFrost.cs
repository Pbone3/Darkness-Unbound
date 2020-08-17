﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace DarknessUnbound.Items.Materials.Souls
{
    public class SoulOfFrost : DarknessItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Frost");
            Tooltip.SetDefault("'The essence of frozen creatures'");

            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.width = item.height = 18;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = ItemRarityID.Orange;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) => Lighting.AddLight(item.position, Color.SkyBlue.ToVector3());

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 50);
        }
    }
}

﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarknessUnbound.Items.Weapons.GemSwords
{
    public class EmeraldSword : DarknessItem
    {
        public override void SafeSetDefaults()
        {
            item.damage = 16;
            item.melee = true;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5.5f;
            item.value = Item.sellPrice(0, 0, 40);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1.15f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox) => Dust.NewDustDirect(hitbox.TopLeft(), hitbox.Width, hitbox.Height, 89).noGravity = true;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 10);
            recipe.AddIngredient(ItemID.Emerald, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

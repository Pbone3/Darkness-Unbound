using DarknessUnbound.Dusts;
using DarknessUnbound.Projectiles.Tropidium;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarknessUnbound.Items.Tropidium
{
	public class Seasword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Seasword");
			Tooltip.SetDefault("insert effect tooltip");
		}

		public override void SetDefaults() 
		{
			item.damage = 35;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 35000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.33f;
			item.shoot = ModContent.ProjectileType<SeltzerExplosion>();
			item.shootSpeed = 10f;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(insert bar);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarknessUnbound.Projectiles.Weapons.Throwing
{
    public class TinThrowingKnifePro : ModProjectile
    {
        public override string Texture => "DarknessUnbound/Items/Weapons/Throwing/TinThrowingKnife";

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            aiType = ProjectileID.ThrowingKnife;
        }

        public override bool PreAI()
        {
            projectile.ai[0] -= 0.35f;
            return true;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 6; i++)
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Tin, 0, 0, 0, default, 0.75f);
            }
            Main.PlaySound(SoundID.Dig, projectile.Center);
        }
    }
}

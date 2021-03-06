﻿using DarknessUnbound.Items.Consumables;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarknessUnbound
{
    public class DUPlayer : ModPlayer
    {
        public bool eldritchCore;
        public bool icyStone;
        public bool frostfireNecklace;
        public bool godMode;

        public int eldritchCore_CountDown;

        public override void Initialize()
        {
            //SkyManager.Instance.Activate("DarknessUnbound:PillarSky");
            //Filters.Scene["DUPillar"].Activate(default);
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ModContent.ItemType<RestlessShadows>());
            items.Add(item);
        }

        public override void ResetEffects()
        {
            eldritchCore = false;
            icyStone = false;
            frostfireNecklace = false;
            godMode = false;

            eldritchCore_CountDown--;
            if (eldritchCore_CountDown < 0) eldritchCore_CountDown = 0;
        }

        #region OnHitBy
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (eldritchCore && eldritchCore_CountDown == 0) OnHitBy_EldritchCore();
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (eldritchCore && eldritchCore_CountDown == 0) OnHitBy_EldritchCore();
        }

        private void OnHitBy_EldritchCore()
        {
            for (int i = 0; i < 4; i++)
            {
                Projectile proj = Projectile.NewProjectileDirect(player.Center - new Vector2(Main.rand.Next(-215, 216), 800 + Main.rand.Next(-100, 101)), Vector2.UnitY * 8, ProjectileID.LunarFlare, 250, 6f, player.whoAmI);
                proj.velocity = proj.velocity.RotatedBy(proj.DirectionTo(player.Center).ToRotation() - MathHelper.PiOver2);
            }

            eldritchCore_CountDown = 24;
        }
        #endregion

        #region OnHit
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (icyStone && item.magic) OnHit_IcyStone(target);
            if (frostfireNecklace && (item.summon || item.sentry)) OnHit_IcyStone(target);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (icyStone && proj.magic) OnHit_IcyStone(target);
            if (frostfireNecklace && (proj.minion || proj.sentry)) OnHit_IcyStone(target);
        }

        private void OnHit_IcyStone(NPC target) => target.AddBuff(BuffID.Frostburn, Main.rand.Next(2, 7) * 60);
        #endregion

        #region Update
        public override void PostUpdateBuffs()
        {
            if (godMode)
            {
                player.statLife = player.statLifeMax2;
                player.statMana = player.statManaMax2;

                for (int i = 0; i < BuffLoader.BuffCount; i++)
                {
                    if (!Main.debuff[i]) continue;
                    player.buffImmune[i] = true;
                }
            }
        }

        public override void UpdateDead()
        {
            if (godMode)
                player.dead = false;
        }
        #endregion
    }
}

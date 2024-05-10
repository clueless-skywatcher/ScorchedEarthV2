using Microsoft.Xna.Framework;
using ScorchedEarthV2.Buffs;
using ScorchedEarthV2.Content.Projectiles.Minions;
using ScorchedEarthV2.System;
using System;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace ScorchedEarthV2.System.Players
{
    internal class SanguinusPlayer : ModPlayer
    {
        public bool sanguinusIratus = false;
        private float lifeStealPercent = 30;

        int i = 10;

        public override void ResetEffects()
        {
            sanguinusIratus = false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (sanguinusIratus)
            {
                // Heal player by 30% of damage done
                Player.Heal((int)(damageDone * (float)(lifeStealPercent / 100)));
            }
        }

        public override void PostUpdateEquips()
        {
            if (sanguinusIratus)
            {
                bool spawnBlobs = true;

                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].type == ModContent.ProjectileType<SanguinusBloodBlob>()
                        && Main.projectile[i].owner == Player.whoAmI && Main.projectile[i].active)
                    {
                        spawnBlobs = false;
                        break;
                    }
                }

                if (spawnBlobs && !IsCooldownActive())
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int proj = Projectile.NewProjectile(
                            Terraria.Entity.GetSource_NaturalSpawn(),
                            Player.Center,
                            Vector2.Zero,
                            ModContent.ProjectileType<SanguinusBloodBlob>(),
                            100, 0,
                            Player.whoAmI,
                            90, 1
                        );

                        Main.projectile[proj].localAI[i] = 2f * MathHelper.Pi / 3f * i;
                    }
                }

                Player.AddBuff(ModContent.BuffType<SanguinusIratusBuff>(), 2);
            }
            else
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].type == ModContent.ProjectileType<SanguinusBloodBlob>()
                        && Main.projectile[i].owner == Player.whoAmI && Main.projectile[i].active)
                    {
                        Main.projectile[i].active = false;
                    }
                }
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Player.dead)
            {
                return;
            }
        }

        public bool IsCooldownActive()
        {
            return Player.HasBuff<SanguinusIratusCooldown>();
        }
    }
}

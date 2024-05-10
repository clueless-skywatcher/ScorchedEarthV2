using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ScorchedEarthV2.System;
using ScorchedEarthV2.Buffs;
using ScorchedEarthV2.System.Players;

namespace ScorchedEarthV2.Content.Projectiles.Minions
{
    internal class SanguinusBloodBlob : ModProjectile
    {

        private bool projectileFired = false;

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Projectile.penetrate = -1;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.timeLeft = 150;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 1, 0, 0);

            Player player = Main.player[Projectile.owner];
            if (!player.active || player.dead)
            {
                Projectile.Kill();
                return;
            }

            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
            Main.dust[dust].velocity = Projectile.velocity;
            Main.dust[dust].noGravity = true;

            if (ScorchedEarthKeys.ArmorAbilityKey.JustPressed)
            {
                SanguinusPlayer modPlayer = player.GetModPlayer<SanguinusPlayer>();
                if (modPlayer.sanguinusIratus)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        NPC target = Main.npc[i];

                        float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
                        float shootToY = target.position.Y - Projectile.Center.Y;
                        float distance = (float)Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        if (distance < 480f && !target.friendly && target.active && !target.CountsAsACritter)
                        {
                            if (Projectile.ai[0] > 4f)
                            {
                                distance = 3f / distance;

                                shootToX *= distance * 5;
                                shootToY *= distance * 5;

                                Projectile.NewProjectile(Terraria.Entity.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, shootToX, shootToY, ModContent.ProjectileType<SanguinusBloodBlobActive>(), 100, 1, Main.myPlayer, 0f, 0f); //Spawning a projectile
                                Projectile.ai[0] = 0f;

                                projectileFired = true;
                            }
                        }
                    }

                    if (projectileFired)
                    {
                        Main.player[Projectile.owner].AddBuff(ModContent.BuffType<SanguinusIratusCooldown>(), 5 * 60);
                    }
                }
            }
            else
            {
                Projectile.damage = 0;
                Projectile.timeLeft = 2;
                float orbitSpeed = 6 / (Projectile.ai[0] / 100);
                float radius = Projectile.ai[0];

                Projectile.localAI[1] += 2f * (float)Math.PI / 600f * orbitSpeed;
                Projectile.localAI[1] %= 2f * (float)Math.PI;

                Vector2 dir = Vector2.Normalize(player.Center - Projectile.Center);
                Projectile.rotation = (float)Math.Atan2(dir.Y, dir.X) + 1.57f;
                Projectile.Center = player.Center + radius * new Vector2((float)Math.Cos(Projectile.localAI[1]), (float)Math.Sin(Projectile.localAI[1]));

                Projectile.ai[0] += 0.4F * Projectile.ai[1];
                if (Projectile.ai[0] >= 100)
                    Projectile.ai[1] = -1;
                else if (Projectile.ai[0] <= 40)
                    Projectile.ai[1] = 1;
            }
        }
    }
}
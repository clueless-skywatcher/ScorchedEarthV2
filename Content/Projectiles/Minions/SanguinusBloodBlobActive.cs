using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Projectiles.Minions
{
    internal class SanguinusBloodBlobActive : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Summon;

            Projectile.friendly = true;
            Projectile.hostile = false;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 1, 0, 0);

            float maxDetectRadius = 200f;
            float projSpeed = 5f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;

            int dust = Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height, DustID.Blood);
            Main.dust[dust].velocity = Projectile.velocity;
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.friendly)
            {
                Main.player[Projectile.owner].statLife += 100;
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 newVelocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(180));
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood, 0f, 0f, 0, default(Color), 1.5f);
                Main.dust[dust].velocity = newVelocity;
            }
        }

        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs(max always 200)
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                if (target.CanBeChasedBy())
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
    }
}

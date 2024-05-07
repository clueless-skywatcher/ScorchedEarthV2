using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ScorchedEarthV2.Content.Items.Weapons.Hamaxes
{
    internal class JellyHamaxe: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 38;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;
            Item.useTurn = true;

            Item.damage = 11;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 3f;

            Item.axe = 7;
            Item.hammer = 28;

            Item.value = Item.buyPrice(silver: 2);
            Item.rare = ItemRarityID.Blue;

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Gel, 11)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ScorchedEarthV2.Content.Items.Weapons.Pickaxes
{
    internal class JellyPickaxe: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;
            Item.useTurn = true;

            Item.damage = 7;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 2.8f;

            Item.pick = 35;

            Item.value = Item.buyPrice(silver: 1, copper: 29);
            Item.rare = ItemRarityID.Blue;

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Gel, 9)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ScorchedEarthV2.Content.Items.Weapons.Swords
{
    internal class JellySword: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            Item.damage = 10;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 3.5f;
            Item.useTurn = true;

            Item.value = Item.buyPrice(copper: 60);
            Item.rare = ItemRarityID.Blue;

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Gel, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}

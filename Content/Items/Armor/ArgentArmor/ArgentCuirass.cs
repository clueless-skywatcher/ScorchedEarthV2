using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.ArgentArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class ArgentCuirass: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 3, silver: 45);
            Item.rare = ItemRarityID.Pink;

            Item.defense = 11;

            ArmorIDs.Body.Sets.HidesBottomSkin[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 10)
                .AddIngredient(ItemID.SilverBar, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.ArgentArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class ArgentGreaves: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 9;

            ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
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

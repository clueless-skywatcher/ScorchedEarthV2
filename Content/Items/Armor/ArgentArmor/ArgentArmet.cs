using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.ArgentArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class ArgentArmet: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 34;

            Item.value = Item.buyPrice(gold: 5, silver: 81);
            Item.rare = ItemRarityID.Pink;

            Item.defense = 10;

            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ArgentCuirass>()
                && legs.type == ModContent.ItemType<ArgentGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.moveSpeed += 0.30f;
            Lighting.AddLight(player.Center, 1f, 1f, 1f);
            player.setBonus = Language.GetTextValue("Mods.ScorchedEarthV2.Items.SetBonuses.ArgentArmor");
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

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace ScorchedEarthV2.Content.Items.Armor.JellyArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class JellyHelmet: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;

            Item.value = Item.buyPrice(silver: 60);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 3;

            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = false;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.10f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<JellyChestplate>()
                && legs.type == ModContent.ItemType<JellyPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.moveSpeed += 0.15f;
            player.setBonus = Language.GetTextValue("Mods.ScorchedEarthV2.Items.SetBonuses.JellyArmor");
        }
    }
}

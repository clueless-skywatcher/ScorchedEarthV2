using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.LinariteArmor {
    [AutoloadEquip(EquipType.Head)]
    internal class LinariteBarbute: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 34;

            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Purple;

            Item.defense = 18;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<LinaritePlatemail>()
                && legs.type == ModContent.ItemType<LinariteJambeaux>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.moveSpeed += 0.30f;
            player.lifeRegen = (int)(player.lifeRegen * 1.30f);
            player.slowFall = true;
            player.setBonus = Language.GetTextValue("Mods.ScorchedEarthV2.Items.SetBonuses.LinariteArmor");
        }
    }
}
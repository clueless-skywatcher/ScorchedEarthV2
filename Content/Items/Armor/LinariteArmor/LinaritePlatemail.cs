using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.LinariteArmor {
    [AutoloadEquip(EquipType.Body)]
    internal class LinaritePlatemail: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 34;

            Item.value = Item.buyPrice(gold: 8);
            Item.rare = ItemRarityID.Purple;

            Item.defense = 18;

            ArmorIDs.Body.Sets.HidesBottomSkin[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }
    }
}
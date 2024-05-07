using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.LinariteArmor {
    [AutoloadEquip(EquipType.Legs)]
    internal class LinariteJambeaux: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 34;

            Item.value = Item.buyPrice(gold: 8, silver: 50);
            Item.rare = ItemRarityID.Purple;

            Item.defense = 15;

            ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
        }
    }
}
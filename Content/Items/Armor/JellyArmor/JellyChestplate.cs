using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.JellyArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class JellyChestplate: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 18;

            Item.value = Item.buyPrice(silver: 70);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 3;

            ArmorIDs.Body.Sets.HidesBottomSkin[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }
    }
}

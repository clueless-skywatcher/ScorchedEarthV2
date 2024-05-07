using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.JellyArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class JellyPants: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;

            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 3;

            ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.07f;
        }
    }
}

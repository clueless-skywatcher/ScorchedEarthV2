using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.SanguinusArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class SanguinusOculus: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 24;

            Item.rare = ItemRarityID.Purple;

            Item.defense = 25;

            ArmorIDs.Body.Sets.HidesBottomSkin[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }

        public override void AddRecipes()
        {
            
        }

        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
        }
    }
}

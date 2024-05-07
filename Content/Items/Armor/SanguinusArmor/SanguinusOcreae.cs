using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.SanguinusArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SanguinusOcreae: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 26;

            Item.rare = ItemRarityID.Purple;

            Item.defense = 21;

            ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.20f;
            player.lifeRegen = (int)(player.lifeRegen * 1.80f);
        }

        public override void AddRecipes()
        {
            
        }
    }
}

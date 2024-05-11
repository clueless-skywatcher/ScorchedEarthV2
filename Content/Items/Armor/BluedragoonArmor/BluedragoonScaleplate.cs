using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ScorchedEarthV2.Content.Items.Armor.BluedragoonArmor {
    [AutoloadEquip(EquipType.Body)]
    internal class BluedragoonScaleplate: ModItem {
        public override void SetDefaults()
        {
            ArmorIDs.Body.Sets.HidesBottomSkin[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }
    }
}
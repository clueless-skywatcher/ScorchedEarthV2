using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ScorchedEarthV2.Content.Items.Armor.BluedragoonArmor {
    [AutoloadEquip(EquipType.Legs)]
    internal class BluedragoonGreaveSabatons: ModItem {
        public override void SetDefaults()
        {
            ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
        }
    }
}
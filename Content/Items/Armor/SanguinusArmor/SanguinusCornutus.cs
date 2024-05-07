using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace ScorchedEarthV2.Content.Items.Armor.SanguinusArmor
{
    [AutoloadEquip(EquipType.Head)]
    internal class SanguinusCornutus: ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 26;

            Item.rare = ItemRarityID.Purple;

            Item.defense = 24;

            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SanguinusOculus>()
                && legs.type == ModContent.ItemType<SanguinusOcreae>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.lifeSteal = 0.30f;

            player.GetCritChance(DamageClass.Melee) = 20;
            player.GetCritChance(DamageClass.Ranged) = 20;

            player.GetDamage(DamageClass.Melee) += 0.25f;
            player.GetDamage(DamageClass.Ranged) += 0.25f;
            
            player.setBonus = Language.GetTextValue("Mods.ScorchedEarthV2.Items.SetBonuses.SanguinusArmor");
        }

        public override void AddRecipes()
        {
            
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) = 15;
            player.GetCritChance(DamageClass.Ranged) = 15;

            player.statLifeMax2 += 100;
        }
    }
}

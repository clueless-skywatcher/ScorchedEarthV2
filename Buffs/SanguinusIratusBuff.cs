using Terraria;
using Terraria.ModLoader;

namespace ScorchedEarthV2.Buffs {
    internal class SanguinusIratusBuff: ModBuff {
        public override void SetStaticDefaults()
        {
			Main.buffNoTimeDisplay[Type] = true;
		}
    }
}
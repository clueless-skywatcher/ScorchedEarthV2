using Terraria.ModLoader;

namespace ScorchedEarthV2.System
{
    public class ScorchedEarthKeys : ModSystem
    {
        public static ModKeybind ArmorAbilityKey { get; private set; }

        public override void Load()
        {
            ArmorAbilityKey = KeybindLoader.RegisterKeybind(Mod, "ArmorAbility", "Q");
        }

        public override void Unload()
        {
            ArmorAbilityKey = null;
        }
    }
}
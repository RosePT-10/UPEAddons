using MelonLoader;

[assembly: MelonInfo(typeof(UPEAddons.Core), "UPEAddons", "1.0.0", "taldo", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace UPEAddons
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
    }
}
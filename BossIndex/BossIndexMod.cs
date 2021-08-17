using BossIndex.Common.CrossMod.Call;
using BossIndex.Core;
using BossIndex.Core.BossInfoBuilding;
using log4net;
using PboneLib.CustomLoading;
using PboneLib.CustomLoading.Content;
using PboneLib.Services.CrossMod;
using PboneLib.Utils;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace BossIndex
{
    public class BossIndexMod : Mod
    {
        public static BossIndexMod Instance => ModContent.GetInstance<BossIndexMod>();

        public static ILog Log => Instance.Logger;

        public static IBossIndexInformationEngine InformationEngine => Instance.InfoEngine;

        public static IBossIndexInformationView InformationView => Instance.InfoView;

        public static BossIndexInfoFactory InformationFactory => Instance.InfoFactory;

        public static CrossModManager CrossMod => Instance.CrossModManager;

        public IBossIndexInformationEngine InfoEngine;
        public IBossIndexInformationView InfoView;
        public BossIndexInfoFactory InfoFactory;
        protected CrossModManager CrossModManager;

        public override void Load()
        {
            base.Load();

            InfoFactory = new BossIndexInfoFactory();

            CrossModManager = new CrossModManager();
            CrossModManager.CallManager.RegisterHandler<AddInfo>();

            // Custom Loading
            CustomModLoader loader = new(this);

            // ModConfigs
            ContentLoader cLoader = new(content =>
            {
                // TODO Unhardcode me! Method in PConfig
                AddConfig(content.Content.GetType().Name, (ModConfig) content.Content);
            })
            {
                Settings =
                {
                    TryToLoadConditions = ContentLoader.ContentLoaderSettings.PresetTryToLoadConfigConditions
                }
            };

            loader.Add(cLoader);

            // Everything else
            cLoader = new ContentLoader(this.AddContent)
            {
                Settings =
                {
                    TryToLoadConditions = ContentLoader.ContentLoaderSettings.PresetNormalTryToLoadConditions
                }
            };

            // Added for clarity, the Action only ctor automatically calls FillWithDefaultConditions
            loader.Add(cLoader);

            // TODO: Fix localization loading in PboneLib!
            loader.Add(new PboneLib.CustomLoading.Localization.LocalizationLoader(LocalizationLoader.AddTranslation));

            loader.Load();
        }

        public void SetInformationEngine(IBossIndexInformationEngine engine)
        {
            InfoEngine?.TransferBossInfo(engine);
            InfoEngine = engine;
        }
    }
}
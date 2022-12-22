using System;
using System.IO;
using Newtonsoft.Json;
namespace EpicMenu
{
    public class Config
    {
        public static void Load()
        {
            string jsonString = File.ReadAllText(Environment.CurrentDirectory + "\\EpicMenu\\config.json");
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            if (json != null)
            {
                QuickMenuBG.quickMenuBGEnabled = json.CustomQMBackground;
                QuickMenuBG.lwEnabled = json.CustomQMLWing;
                QuickMenuBG.rwEnabled = json.CustomQMRWing;
                QuickMenuBG.bannersEnabled = json.CustomBanners;
                QuickMenuBG.bannerDelay = json.BannersChangeRate;
                
                MainMenuBG.mainMenuBGEnabled = json.CustomMMBackground;
                MainMenuBG.lwEnabled = json.CustomMMLWing;
                MainMenuBG.rwEnabled = json.CustomMMRWing;
            }
        }
    }
}
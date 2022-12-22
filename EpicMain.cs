using System;
using System.Collections;
using System.IO;
using MelonLoader;
using UnityEngine;
using VRC.UI.Elements;

namespace EpicMenu
{
    public class EpicMain : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Config.Load();
            MelonCoroutines.Start(WaitForUi());
            base.OnInitializeMelon();
        }

        public static float ExtractDelay(string fileName)
        {
            string[] parts = fileName.Split('_');
            string delayPart = parts[2];
            string[] delayParts = delayPart.Split('-');
            string delay = delayParts[1];
            delay = delay.Replace("s.png", "");
            return float.Parse(delay);
        }

        public static IEnumerator WaitForUi()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null) yield return null;
            while (QuickMenuBG.getQuickMenu().transform.Find("CanvasGroup/Container/Window/QMParent/BackgroundLayer01") == null) yield return null;
            while (VRCVrCamera.field_Private_Static_VRCVrCamera_0.field_Public_Camera_0.gameObject == null) yield return null;
            QuickMenuBG.InitializeQM();
            MainMenuBG.InitializeMM();
            
        }

        public static Sprite[] LoadGif(string path)
        {
            string[] files = Directory.GetFiles(path, "*.png");
            Sprite [] sprites = new Sprite[files.Length];
            for(int i = 0 ; i < files.Length ; i++)
            {
                byte[] fileData = File.ReadAllBytes(files[i]);
                Texture2D texture = new Texture2D(2, 2);
                Il2CppImageConversionManager.LoadImage(texture, fileData);
                sprites[i] = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f, 0, 0, new Vector4(), false);
                sprites[i].hideFlags |= HideFlags.DontUnloadUnusedAsset;
            }

            return sprites;
        }
    }
}
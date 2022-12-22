using System;
using System.Collections;
using System.IO;
using UnityEngine;
using MelonLoader;
using UnityEngine.UI;
using VRC.UI.Elements;

namespace EpicMenu
{
    public class QuickMenuBG
    {
        //useful shit
        private static GameObject quickMenu;
        
        
        //quick menu background
        public static bool quickMenuBGEnabled;
        private static GameObject qmBack;
        private static int qmBackIndex = 1;
        private static float qmBackDelay = EpicMain.ExtractDelay(Directory.GetFiles($"{Environment.CurrentDirectory}\\EpicMenu\\QMBack\\",  "*.png")[0]);
        private static Sprite[] qmBackSprites = EpicMain.LoadGif($"{Environment.CurrentDirectory}\\EpicMenu\\QMBack\\");
        
        //right wing background
        public static bool rwEnabled;
        private static GameObject rwBack;
        private static int rwBackIndex = 1;
        private static float rwBackDelay = EpicMain.ExtractDelay(Directory.GetFiles($"{Environment.CurrentDirectory}\\EpicMenu\\RWBack\\",  "*.png")[0]);
        private static Sprite[] rwBackSprites = EpicMain.LoadGif($"{Environment.CurrentDirectory}\\EpicMenu\\RWBack\\");
        
        //left wing background
        public static bool lwEnabled;
        private static GameObject lwBack;
        private static int lwBackIndex = 1;
        private static float lwBackDelay = EpicMain.ExtractDelay(Directory.GetFiles($"{Environment.CurrentDirectory}\\EpicMenu\\LWBack\\",  "*.png")[0]);
        private static Sprite[] lwBackSprites = EpicMain.LoadGif($"{Environment.CurrentDirectory}\\EpicMenu\\LWBack\\");
        
        //banners
        public static bool bannersEnabled;
        private static GameObject banner;
        private static int bannerIndex = 1;
        public static float bannerDelay = 5;
        private static Sprite[] bannerSprites = EpicMain.LoadGif($"{Environment.CurrentDirectory}\\EpicMenu\\Banner\\");

        public static void InitializeQM()
        {
            if(quickMenuBGEnabled)
                QMSetup();
            if(lwEnabled)
                LWSetup();
            if(rwEnabled)
                RWSetup();
            if(bannersEnabled)
                BannerSetup();
        }
        
        public static GameObject getQuickMenu()
        {
            if (quickMenu == null)
                quickMenu = Resources.FindObjectsOfTypeAll<QuickMenu>()[0].gameObject;
            return quickMenu;
        }
        
        public static void QMSetup()
        {
            qmBack = getQuickMenu().transform.Find("CanvasGroup/Container/Window/QMParent/BackgroundLayer01").gameObject;
            qmBack.GetComponent<Image>().overrideSprite = qmBackSprites[0];
            MelonLogger.Msg("Quick Menu Background Initialized");
            MelonCoroutines.Start(QMBack());
        }
        
        public static IEnumerator QMBack()
        {
            while (true)
            {
                if (quickMenu.GetComponent<QuickMenu>().enabled)
                {
                    qmBack.GetComponent<Image>().overrideSprite = qmBackSprites[qmBackIndex];
                    if (qmBack.GetComponent<Image>().color != Color.white)
                        qmBack.GetComponent<Image>().color = Color.white;
                    qmBackIndex++;
                    if (qmBackIndex >= qmBackSprites.Length) qmBackIndex = 0;
                }

                yield return new WaitForSeconds(qmBackDelay);
            }
        }
        
        public static void RWSetup()
        {
            rwBack = getQuickMenu().transform.Find("CanvasGroup/Container/Window/Wing_Right/Container/InnerContainer/Background").gameObject;
            rwBack.GetComponent<Image>().overrideSprite = rwBackSprites[0];
            MelonLogger.Msg("Right Wing Background Initialized");
            MelonCoroutines.Start(RWBack());
        }
        
        public static IEnumerator RWBack()
        {
            while (true)
            {
                if (quickMenu.GetComponent<QuickMenu>().enabled)
                {
                    rwBack.GetComponent<Image>().overrideSprite = rwBackSprites[rwBackIndex];
                    if (rwBack.GetComponent<Image>().color != Color.white)
                        rwBack.GetComponent<Image>().color = Color.white;
                    rwBackIndex++;
                    if (rwBackIndex >= rwBackSprites.Length) rwBackIndex = 0;
                }

                yield return new WaitForSeconds(rwBackDelay);
            }
        }
        
        public static void LWSetup()
        {
            lwBack = getQuickMenu().transform.Find("CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/Background").gameObject;
            lwBack.GetComponent<Image>().overrideSprite = lwBackSprites[0];
            MelonLogger.Msg("Left Wing Background Initialized");
            MelonCoroutines.Start(LWBack());
        }
        
        public static IEnumerator LWBack()
        {
            while (true)
            {
                if (quickMenu.GetComponent<QuickMenu>().enabled)
                {
                    lwBack.GetComponent<Image>().overrideSprite = lwBackSprites[lwBackIndex];
                    if (lwBack.GetComponent<Image>().color != Color.white)
                        lwBack.GetComponent<Image>().color = Color.white;
                    lwBackIndex++;
                    if (lwBackIndex >= lwBackSprites.Length) lwBackIndex = 0;
                }

                yield return new WaitForSeconds(lwBackDelay);
            }
        }

        private static void BannerSetup()
        {
            banner = getQuickMenu().transform.Find("CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners/Image_MASK/Image").gameObject;
            UnityEngine.Object.Destroy(banner.transform.Find("ItemCounter").gameObject);
            UnityEngine.Object.Destroy(banner.transform.Find("Banners").gameObject);
            UnityEngine.Object.Destroy(banner.transform.Find("Controls_Left").gameObject);
            UnityEngine.Object.Destroy(banner.transform.Find("Controls_Right").gameObject);
            UnityEngine.Object.Destroy(banner.transform.Find("LoadingIcon").gameObject);
            banner.GetComponent<Image>().overrideSprite = bannerSprites[0];
            MelonLogger.Msg("Banner Initialized");
            MelonCoroutines.Start(Banner());
        }
        
        public static IEnumerator Banner()
        {
            while (true)
            {
                if (quickMenu.GetComponent<QuickMenu>().enabled)
                {
                    banner.GetComponent<Image>().overrideSprite = bannerSprites[bannerIndex];
                    if (banner.GetComponent<Image>().color != Color.white)
                        banner.GetComponent<Image>().color = Color.white;
                    bannerIndex++;
                    if (bannerIndex >= bannerSprites.Length) bannerIndex = 0;
                }

                yield return new WaitForSeconds(bannerDelay);
            }
        }
    }
}
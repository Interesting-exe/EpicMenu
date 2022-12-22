using System;
using System.Collections;
using System.IO;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace EpicMenu
{
    public class MainMenuBG
    {
        //Main menu background
        public static bool mainMenuBGEnabled;
        private static GameObject mainMenuBG;
        private static int mainMenuBGIndex = 1;
        private static float mmDelay = EpicMain.ExtractDelay(Directory.GetFiles($"{Environment.CurrentDirectory}\\EpicMenu\\MMBack\\", "*.png")[0]);
        private static Sprite[] mmSprites = EpicMain.LoadGif($"{Environment.CurrentDirectory}\\EpicMenu\\MMBack\\");
        
        //Main menu right wing
        public static bool rwEnabled;
        private static GameObject rwBack;
        private static int rwBackIndex = 1;
        private static float rwBackDelay = EpicMain.ExtractDelay(Directory.GetFiles($"{Environment.CurrentDirectory}\\EpicMenu\\MMRightWing\\", "*.png")[0]);
        private static Sprite[] rwBackSprites = EpicMain.LoadGif($"{Environment.CurrentDirectory}\\EpicMenu\\MMRightWing\\");
        
        //Main menu left wing
        public static bool lwEnabled;
        private static GameObject lwBack;
        private static int lwBackIndex = 1;
        private static float lwBackDelay = EpicMain.ExtractDelay(Directory.GetFiles($"{Environment.CurrentDirectory}\\EpicMenu\\MMLeftWing\\", "*.png")[0]);
        private static Sprite[] lwBackSprites = EpicMain.LoadGif($"{Environment.CurrentDirectory}\\EpicMenu\\MMLeftWing\\");
        

        public static void InitializeMM()
        {
            if(mainMenuBGEnabled)
                MMSetup();
            if(lwEnabled)
                LWSetup();
            if(rwEnabled)
                RWSetup();
        }
        
        public static void MMSetup()
        {
            mainMenuBG = QuickMenuBG.getQuickMenu().transform.parent.Find("Canvas_MainMenu(Clone)/Container/MMParent/BackgroundLayer01").gameObject;
            mainMenuBG.GetComponent<Image>().overrideSprite = mmSprites[0];
            MelonLogger.Msg("Main menu background initialized");
            MelonCoroutines.Start(QMBack());
        }
        
        public static IEnumerator QMBack()
        {
            while (true)
            {
                if (QuickMenuBG.getQuickMenu().transform.parent.Find("Canvas_MainMenu(Clone)").gameObject.GetComponent<VRC.UI.Elements.MenuStateController>().enabled)
                {
                    mainMenuBG.GetComponent<Image>().overrideSprite = mmSprites[mainMenuBGIndex];
                    if (mainMenuBG.GetComponent<Image>().color != Color.white)
                        mainMenuBG.GetComponent<Image>().color = Color.white;
                    mainMenuBGIndex++;
                    if (mainMenuBGIndex >= mmSprites.Length) mainMenuBGIndex = 0;
                }

                yield return new WaitForSeconds(mmDelay);
            }
        }
        
        public static void RWSetup()
        {
            rwBack = QuickMenuBG.getQuickMenu().transform.parent.Find("Canvas_MainMenu(Clone)/Container/Wing_Right/Container/InnerContainer/Background").gameObject;
            rwBack.GetComponent<Image>().overrideSprite = rwBackSprites[0];
            MelonLogger.Msg("Main menu right wing initialized");
            MelonCoroutines.Start(RWBack());
        }
        
        public static IEnumerator RWBack()
        {
            while (true)
            {
                if (QuickMenuBG.getQuickMenu().transform.parent.Find("Canvas_MainMenu(Clone)").gameObject.GetComponent<VRC.UI.Elements.MenuStateController>().enabled)
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
            lwBack = QuickMenuBG.getQuickMenu().transform.parent.Find("Canvas_MainMenu(Clone)/Container/Wing_Left/Container/InnerContainer/Background").gameObject;
            lwBack.GetComponent<Image>().overrideSprite = lwBackSprites[0];
            MelonLogger.Msg("Main menu left wing initialized");
            MelonCoroutines.Start(LWBack());
        }
        
        public static IEnumerator LWBack()
        {
            while (true)
            {
                if (QuickMenuBG.getQuickMenu().transform.parent.Find("Canvas_MainMenu(Clone)").gameObject.GetComponent<VRC.UI.Elements.MenuStateController>().enabled)
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
    }
}
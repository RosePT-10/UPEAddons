using MelonLoader;
using Unity.Collections.LowLevel.Unsafe;
using System;
using UnityEngine;
using Il2CppView_Audio;
using Il2CppMS.Internal.Xml.XPath;
using Il2CppSystem.Net.Cache;
using UnityEngine.ResourceManagement.ResourceProviders;
using Il2CppSystem.Linq;
using UnityEngine.UI;
using MelonLoader.ICSharpCode.SharpZipLib.Zip;

[assembly: MelonInfo(typeof(UPEAddons.Core), "UPEAddons", "1.0.0", "RosePT-10", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace UPEAddons
{
    public class Core : MelonMod
    {
        public UnityEngine.GameObject jumpscare_game_object;
        public UnityEngine.Texture jump_scare_texture;
        AssetBundle bundle;

        int timer; // check once every second
        bool y_or_n; // rng check
        string path;

        private void DrawImage()
        {   
            LoggerInstance.Msg(jump_scare_texture);
            GUI.DrawTexture(new Rect(0, 0, 1000, 1000), jump_scare_texture);
        }
        private bool CheckRng()
        {
            int rng = System.Random.Shared.Next(0, 10000);
            //LoggerInstance.Msg(rng);
            if (rng == 1)
            {
                y_or_n = true;
            }
            else
            {
                y_or_n = false;
            }

            return y_or_n;
        }
        public override void OnInitializeMelon()
        {
            // initialize asset bundle
            bundle = AssetBundle.LoadFromFile("D:/_AIRFRAME ULTRA/_Mods and tools/_RoseMods/UPEAddons/UPEAddons/jump_scare.assets");
            if (bundle == null)
            {
                LoggerInstance.Msg("Failed to load custom asset bundle :[");
            }
            else
            {
                LoggerInstance.Msg("Loaded custom asset bundle");
            }

            // initialize texture stuff
            

            // set timer
            timer = 0;

            LoggerInstance.Msg("Successfully Initialized! Yipee!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);

            // testing jumpscare
            if (sceneName == "MainMenu")
            {
                jumpscare_game_object = bundle.LoadAsset<GameObject>("JumpScareAudio");
                GameObject.Instantiate(jumpscare_game_object);
                jumpscare_game_object.GetComponent<AudioSource>().Play();
                jump_scare_texture = bundle.LoadAsset<Texture>("AFU Beta Disclaimer");
                Texture.Instantiate(jump_scare_texture);
                if (jump_scare_texture == null)
                {
                    LoggerInstance.Msg("didnt work"); 
                }
                else
                {
                    LoggerInstance.Msg("Worked!"); 
                }
                MelonEvents.OnGUI.Subscribe(DrawImage, 0);
            }
        }
        

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            // only check once every second
            if (timer >= 50)
            {
                timer = 0;

                // play jumpscare this frame depending on rng
                //LoggerInstance.Msg("Checking rng...");
                CheckRng();
                if (y_or_n == true)
                {
                    jumpscare_game_object = bundle.LoadAsset<GameObject>("JumpScareAudio");
                    GameObject.Instantiate(jumpscare_game_object);
                    jumpscare_game_object.GetComponent<AudioSource>().Play();
                    LoggerInstance.Msg("Played jump scare sound this frame.");
                }
                else
                {
                    //LoggerInstance.Msg("\"You missed that one, try another!\"");
                }
            }
            else
            {
                timer ++;
                //LoggerInstance.Msg(timer);
            }
            
            
        }

        

        public override void OnApplicationQuit()
        {
            base.OnApplicationQuit();
            bundle.Unload(true);
            LoggerInstance.Msg("Unloaded custom asset bundle");
        }
        
    }
}
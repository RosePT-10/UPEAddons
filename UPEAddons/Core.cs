using MelonLoader;
using Unity.Collections.LowLevel.Unsafe;
using System;
using UnityEngine;
using Il2CppView_Audio;
using Il2CppMS.Internal.Xml.XPath;
using Il2CppSystem.Net.Cache;
using UnityEngine.ResourceManagement.ResourceProviders;
using Il2CppSystem.Linq;

[assembly: MelonInfo(typeof(UPEAddons.Core), "UPEAddons", "1.0.0", "RosePT-10", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace UPEAddons
{
    public class Core : MelonMod
    {
        AudioSource audio;
        AudioClip noise_clip;
        public UnityEngine.GameObject jumpscare_game_object;
        UnityEngine.AudioSource noise_audio_source;
        AssetBundle bundle;

        bool y_or_n; // rng check
        string path;
        string path_to_noise_clip;

        IEnumerator<AssetBundleCreateRequest> LoadFromMemoryAsync(string path)
        {
            AssetBundleCreateRequest createRequest = AssetBundle.LoadFromMemoryAsync
            (
                File.ReadAllBytes
                (
                    path
                )
            );
            yield return createRequest;
            bundle = createRequest.assetBundle;

        }
        public override void OnInitializeMelon()
        {
            // initialize asset bundle
            //LoadFromMemoryAsync("D:/_AIRFRAME ULTRA/_Mods and tools/_RoseMods/UPEAddons/UPEAddons/jump_scare.assets");
            bundle = AssetBundle.LoadFromFile("D:/_AIRFRAME ULTRA/_Mods and tools/_RoseMods/UPEAddons/UPEAddons/jump_scare.assets");
            if (bundle == null)
            {
                LoggerInstance.Msg("Failed to load custom asset bundle :[");
            }
            else
            {
                LoggerInstance.Msg("Loaded custom asset bundle");
            }
            

            // testing
            

            
            
            // find where the .wav should be stored
            //path = Application.dataPath;
            //int dotdot = path.LastIndexOf('/');
            //path = path.Remove(dotdot, 19); // go back one folder
            //path = path.Insert(dotdot, "/UserData/UPEAddons/AudioClip"); 
            //path_to_noise_clip = path + "/Poke.wav";
            //LoggerInstance.Msg(path);
            //LoggerInstance.Msg(path_to_noise_clip);

            // get the .wav as an audioclip
            //noise_clip = bundle.LoadAsset<AudioClip>("Poke");
            //LoggerInstance.Msg(noise_clip.name);
            
            // initialize the jump scare audioclip
            jumpscare_game_object = bundle.LoadAsset<GameObject>("JumpScare");
            LoggerInstance.Msg(jumpscare_game_object.name);
            noise_audio_source = jumpscare_game_object.GetComponent<AudioSource>();
            LoggerInstance.Msg(noise_audio_source.name);
            //noise_audio_source.clip = bundle.LoadAsset<AudioClip>("Poke");
            AudioClip test = jumpscare_game_object.GetComponent<AudioSource>().clip;
            if (test == null)
            {
                LoggerInstance.Msg("didn't work :[");
            }
            else
            {
                LoggerInstance.Msg("worked!!!!!!");
            }
            
            
            
            //noise_sound_player = UnityEngine.GameObject.Find("Audio_Main");
            //LoggerInstance.Msg(sound_file);
            //jump_scare = 
            //jump_scare.LoadAudioData();

            LoggerInstance.Msg("Successfully Initialized! Yipee!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            if (sceneName == "MainMenu")
            {
                jumpscare_game_object = bundle.LoadAsset<GameObject>("JumpScare");
                LoggerInstance.Msg(jumpscare_game_object.name);
                GameObject.Instantiate(jumpscare_game_object);
                LoggerInstance.Msg("survived");
                jumpscare_game_object.GetComponent<AudioSource>().Play();
            }
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            
            // determine if we play noise this frame
            //if (CheckRng() == true)
            //{
                //audio.Play();
            //}
            
        }

        private bool CheckRng()
        {
            int rng = System.Random.Shared.Next(0, 1000);
            if (rng == 1)
            {
                //
            }

            return y_or_n;
        }

        public override void OnApplicationQuit()
        {
            base.OnApplicationQuit();
            bundle.Unload(true);
            LoggerInstance.Msg("Unloaded custom asset bundle");
        }
        
    }
}
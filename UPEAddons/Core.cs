using MelonLoader;
using Unity.Collections.LowLevel.Unsafe;
using System;
using UnityEngine;
using Il2CppView_Audio;
using Il2CppMS.Internal.Xml.XPath;
using Il2CppSystem.Net.Cache;

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
        AssetBundle asset;

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
            AssetBundle bundle = createRequest.assetBundle;

        }
        public override void OnInitializeMelon()
        {
            // initialize asset bundle
            LoadFromMemoryAsync("UPEAddons/jump_scare.assets");

            
            
            // find where the .wav should be stored
            //path = Application.dataPath;
            //int dotdot = path.LastIndexOf('/');
            //path = path.Remove(dotdot, 19); // go back one folder
            //path = path.Insert(dotdot, "/UserData/UPEAddons/AudioClip"); 
            //path_to_noise_clip = path + "/Poke.wav";
            //LoggerInstance.Msg(path);
            //LoggerInstance.Msg(path_to_noise_clip);

            // get the .wav as an audioclip
            //noise_clip = Resources.Load<AudioClip>("Poke");
            //noise_clip.name = "noise_clip";
            //LoggerInstance.Msg(noise_clip.name);
            
            // initialize the jump scare audioclip
            //jumpscare_game_object = new UnityEngine.GameObject();
            //jumpscare_game_object.name = "jumpscare_game_object";

            //jumpscare_game_object.AddComponent<AudioSource>();
            //noise_audio_source = jumpscare_game_object.GetComponent<AudioSource>();
            //noise_audio_source.clip = noise_clip;
            
            
            
            //noise_sound_player = UnityEngine.GameObject.Find("Audio_Main");
            //LoggerInstance.Msg(sound_file);
            //jump_scare = 
            //jump_scare.LoadAudioData();

            LoggerInstance.Msg("Successfully Initialized! Yipee!");
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
        
    }
}
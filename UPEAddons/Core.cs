using MelonLoader;
using Unity.Collections.LowLevel.Unsafe;
using System;
using UnityEngine;
using Il2CppView_Audio;

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

        bool y_or_n; // rng check

        public override void OnInitializeMelon()
        {
            // initialize the jump scare audioclip
            jumpscare_game_object = new UnityEngine.GameObject();
            jumpscare_game_object.name = "jumpscare_game_object";

            jumpscare_game_object.AddComponent<AudioSource>();
            noise_audio_source = jumpscare_game_object.GetComponent<AudioSource>();
            noise_audio_source.clip = noise_clip;
            
            //noise_sound_player = UnityEngine.GameObject.Find("Audio_Main");
            //LoggerInstance.Msg(sound_file);
            //jump_scare = 
            //jump_scare.LoadAudioData();

            LoggerInstance.Msg("Initialized.");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            // determine if we play noise this frame
            if (CheckRng() == true)
            {
                //audio.Play();
            }
            
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
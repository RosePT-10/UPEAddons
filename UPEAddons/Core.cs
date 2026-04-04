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
        AudioClip jump_scare;
        UnityEngine.GameObject jumpscare_sound_player;

        bool y_or_n; // rng check

        public override void OnInitializeMelon()
        {
            // initialize the jump scare audioclip
            jumpscare_sound_player = new UnityEngine.GameObject();
            jumpscare_sound_player.name = "jumpscare_sound_player";
            jumpscare_sound_player.AddComponent<AudioSource>();
            //jumpscare_sound_player = UnityEngine.GameObject.Find("Audio_Main");
            //LoggerInstance.Msg(sound_file);
            //jump_scare = 
            //jump_scare.LoadAudioData();

            LoggerInstance.Msg("Initialized.");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            // determine if we play jumpscare this frame
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
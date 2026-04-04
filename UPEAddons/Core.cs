using MelonLoader;
using Unity.Collections.LowLevel.Unsafe;
using System;
using UnityEngine;

[assembly: MelonInfo(typeof(UPEAddons.Core), "UPEAddons", "1.0.0", "taldo", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace UPEAddons
{
    public class Core : MelonMod
    {
        AudioSource audio;
        AudioClip jump_scare;
        UnityEngine.GameObject sound_file;
        bool y_or_n; // rng check

        public override void OnInitializeMelon()
        {
            // initialize the jump scare audioclip
            sound_file = GameObject.Find("AirframeCrash_01.wav");
            //jump_scare = 
            jump_scare.LoadAudioData();

            LoggerInstance.Msg("Initialized.");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            // determine if we play jumpscare this frame
            if (CheckRng() == true)
            {
                audio.Play();
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
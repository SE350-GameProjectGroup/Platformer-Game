using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, dieSound, dashSound;
    static AudioSource audioSrc;
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jumpeffect2");
        dieSound = Resources.Load<AudioClip>("dieeffect2");
        dashSound = Resources.Load<AudioClip>("dasheffect");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
        public static void PlaySound(string clip)
        {
            switch(clip)
        {
            case "jumpeffect2":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "dieeffect2":
                audioSrc.PlayOneShot(dieSound);
                break;
            case "dasheffect":
                audioSrc.PlayOneShot(dashSound);
                break;

               

        }
        }
    
}

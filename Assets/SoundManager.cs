using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Speaker;
    public AudioClip[] Clipvraag;

    public void PlayAudio(){
        Speaker.clip = Clipvraag[QuizManager.vraagNu];
        Speaker.PlayOneShot(Speaker.clip); //speelt audio na een vraag
    }
}

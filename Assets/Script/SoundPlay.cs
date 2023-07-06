using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public AudioSource sound;

    public void SoundPlayer()
    {
        sound.Play();
    }
}

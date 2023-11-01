using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffect : MonoBehaviour
{
    public static SoundsEffect instance;
    public AudioSource explosionSound, playerLaserSound, impactSound;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }
}

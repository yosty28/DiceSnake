using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupSounds : MonoBehaviour
{
    public SoundLibrairie sl;
    public string[] SonAJouer;
    public AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var s in SonAJouer)
        {
            ad.clip = sl.GetSound(s);
            ad.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
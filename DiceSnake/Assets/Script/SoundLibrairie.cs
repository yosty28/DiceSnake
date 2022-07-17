using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrairie : MonoBehaviour
{
    public AudioClip[] listeSon;

    public Dictionary<string, AudioClip> listeSonDic = new Dictionary<string, AudioClip>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (AudioClip son in listeSon)
        {
            listeSonDic.Add(son.name, son);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioClip GetSound(string nomSon)
    {
        return listeSonDic[nomSon];
    }
}
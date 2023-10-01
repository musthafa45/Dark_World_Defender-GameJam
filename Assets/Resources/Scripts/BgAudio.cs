using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgAudio : MonoBehaviour
{
    public static BgAudio instance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}

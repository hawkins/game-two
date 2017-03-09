using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{

    static bool AudioBegin = false;
    public AudioSource music;

    // Use this for initialization
    void Awake()
    {

        if (!AudioBegin)
        {
            music.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Application.loadedLevelName == "Interior")
        {
            music.Stop();
            AudioBegin = false;
        }

    }
}

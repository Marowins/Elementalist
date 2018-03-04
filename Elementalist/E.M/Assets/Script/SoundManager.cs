using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // static 화
    public static SoundManager instance;

    // AudioSource Require
    public AudioSource hit;
    public AudioSource bgm;
    public AudioSource invenselect;
    public AudioSource magic;

    private void Awake()
    {
        instance = this;
    }

}

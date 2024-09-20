using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] AudioSource bounce;
    [SerializeField] AudioSource boom;
    [SerializeField] AudioSource woosh;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource trashClang;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    private void Start()
    {
        //PlayBG();
    }

    public void PlayBounce()
    {
        bounce.Play();
    }

    public void PlayBoom()
    {
        boom.Play();
    }

    public void PlayWoosh()
    {
        woosh.Play();
    }

    public void PlayClang()
    {
        trashClang.Play();
    }

    public void PlayBG()
    {
        bgMusic.Play();
    }
}

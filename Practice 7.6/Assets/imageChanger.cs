using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageChanger : MonoBehaviour
{
    public Sprite newSpriteON;
    public Sprite newSpriteOFF;
    public AudioClip Clip;

    public Image img;
    private AudioSource audio;

    void Start()
    {
       
       audio = GetComponent<AudioSource>();
       audio.Play();
    }

    public void ChangeSprite()
    {
       if(audio.isPlaying)
            img.sprite = newSpriteON;
       else img.sprite = newSpriteOFF;
        
    }

    public void ChangeColor()
    {
        img.color = Color.blue;
    }

    public void ChangeSoundPlay()
    {
        if(audio.isPlaying) 
            audio.Pause();
        else 
            audio.Play();
    }

    public void ChangeSound()
    {
        audio.clip = Clip;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudio : MonoBehaviour
{
    public bool fadeInOnStart = false;    
    bool fading = false;
    bool fadeDir = false;
    float currentVolPercent = 0;
    float maxVol = 0;
    public AudioSource source;
    public float fadeSpeed;
    private void Awake()
    {
        maxVol = source.volume;
        if (fadeInOnStart) source.volume = 0;
    }
    private void Start()
    {
        
        if(fadeInOnStart) FadeIn();
    }

    public void FadeIn() 
    {
        fading = true;
        fadeDir = true;
        currentVolPercent = 0;
    }
    public void FadeOut() 
    {
        fading = true;
        fadeDir =false;
        currentVolPercent = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (fading) 
        {
            if (fadeDir)
            {
                if (currentVolPercent + Time.deltaTime * fadeSpeed < 1)
                {
                    currentVolPercent += Time.deltaTime * fadeSpeed;

                    source.volume = Mathf.Lerp(0, maxVol, currentVolPercent);
                }
                else 
                {
                    currentVolPercent = 1;
                    source.volume = Mathf.Lerp(0, maxVol, currentVolPercent);
                    fading = false;
                }


            }
            else 
            {
                if (currentVolPercent - Time.deltaTime * fadeSpeed > 0)
                {
                    currentVolPercent -= Time.deltaTime * fadeSpeed;

                    source.volume = Mathf.Lerp(0, maxVol, currentVolPercent);
                }
                else
                {
                    currentVolPercent = 0;
                    source.volume = Mathf.Lerp(0, maxVol, currentVolPercent);
                    fading = false;
                }


            }
        }   
    }
}

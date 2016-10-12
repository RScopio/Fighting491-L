using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                   
    public AudioSource musicSource;                 
    public static SoundManager instance = null;                
    public float lowPitchRange = .95f;              
    public float highPitchRange = 1.05f;            


    void Awake()
    {
        
        if (instance == null)
            
            instance = this;
        
        else if (instance != this)
            
            Destroy(gameObject);

       
        DontDestroyOnLoad(gameObject);
    }


    
    public void PlaySingle(AudioClip clip)
    {
        
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }


    //Selects a random sound from an array and plays it for a specific action
    public void RandomizeSfx(params AudioClip[] clips)
    {
        
        int randomIndex = Random.Range(0, clips.Length);

        
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        
        efxSource.pitch = randomPitch;

        
        efxSource.clip = clips[randomIndex];

        
        efxSource.Play();
    }
}

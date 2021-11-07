using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField]
    AudioSource audioSource;
    
    public static AudioManager instance;
    
    void Awake() 
    {
        if (instance != null && this != instance) {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource.Play();
        }
    }
}

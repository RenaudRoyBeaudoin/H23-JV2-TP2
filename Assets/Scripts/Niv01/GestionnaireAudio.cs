using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class GestionnaireAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    void Start(){
        
    }    
   
    public void GererVolMusique(float volume){
        _audioMixer.SetFloat("VolMusique", volume);
    }

    public void GererVolEffets(float volume){
        _audioMixer.SetFloat("VolEffetsSonores", volume);
    }
}

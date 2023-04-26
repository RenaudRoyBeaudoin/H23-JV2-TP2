using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class GestionMusique : MonoBehaviour
{
    [SerializeField] private GameObject _contientMusique;
    //[SerializeField] private AudioClip _laMusique;
    [SerializeField] private AudioClip[] _listeDeMusique;
    private AudioSource _quelleMusique;


    [SerializeField] private TMP_Text _leTitreDeLaMusique;


    void Start()
    {
        _quelleMusique = _contientMusique.GetComponent<AudioSource>();
    }

  public void ChangeMusique(){
        int nbHasard = Random.Range(0,_listeDeMusique.Length); //_listeDeMusique.Length vient chercher la longueur de mon tableau
        

        _quelleMusique.clip = _listeDeMusique[nbHasard]; //_laMusique;
        _quelleMusique.Play();
        Debug.Log("musique");


        _leTitreDeLaMusique.text = _quelleMusique.clip.name;
  }
}

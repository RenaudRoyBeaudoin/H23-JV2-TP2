using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RemiseDechets : MonoBehaviour
{
    [SerializeField] private InfoJoueur _infoJoueur;
    [SerializeField] private AudioClip _sonWin;
    private AudioSource audioSource;



    //Réfère au script CollisionDechet
    [SerializeField] private CollisionDechet _collisionDechet;


    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    //Remet le compte de points à 0 sile joueur entre dans la zone de remise avec 5 points
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){

            if(_infoJoueur._nbPoints == 5){

                _infoJoueur._nbPoints = 0;

                audioSource.clip = _sonWin;
                audioSource.Play();

                _collisionDechet._estPlein = false;
            }


        }
    }


}

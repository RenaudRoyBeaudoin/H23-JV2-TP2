using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RemiseDechets : MonoBehaviour
{
    //Référence au script timer
    [SerializeField] private Timer _timer;

    //Référence à Infojoueur
    [SerializeField] private InfoJoueur _infoJoueur;

    //Référence à l'audioClip
    [SerializeField] private AudioClip _sonWin;
    private AudioSource audioSource;


    ///Temps supplémentaire accordé au joueur
    [SerializeField] private float _tempsSup;


    //Réfère au script CollisionDechet
    [SerializeField] private CollisionDechet _collisionDechet;


    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    //Remet le compte de points à 0 si le joueur entre dans la zone de remise avec 5 points
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){

            if(_infoJoueur._nbPoints == 5){

                _timer._tempsRestant += _tempsSup;

                _infoJoueur._nbPoints = 0;

                audioSource.clip = _sonWin;
                audioSource.Play();

                _collisionDechet._estPlein = false;
            }


        }
    }


}

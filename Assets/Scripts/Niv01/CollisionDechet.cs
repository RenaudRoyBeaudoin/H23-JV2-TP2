using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollisionDechet : MonoBehaviour
{

    [SerializeField] private InfoJoueur _infoJoueur;
    [SerializeField] private int _nbPoints;

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){

            Debug.Log("collision");

            
            //Enregistre le nombre de point actuel
            _infoJoueur._nbPoints += _nbPoints;

           //Enlève l'objet de la scène
            Destroy(gameObject);

            
        }
    }
}

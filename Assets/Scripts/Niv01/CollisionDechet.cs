using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDechet : MonoBehaviour
{

    [SerializeField] private InfoJoueur _infoJoueur;
    [SerializeField] private int _nbPoints;
    [SerializeField] private int _nbPointsTotals;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){


            if(_infoJoueur._nbPoints !< 5){
            Debug.Log("collision");

            
            //Enregistre le nombre de point(s) actuel(s)
            _infoJoueur._nbPoints += _nbPoints;


            //Enregistre le nombre de points totaux
            _infoJoueur._nbPointsTotals += _nbPoints;

           //Enlève l'objet de la scène
            Destroy(gameObject);
            }
            
        }
    }
}

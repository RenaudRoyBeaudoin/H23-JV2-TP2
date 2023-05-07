using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemiseDechets : MonoBehaviour
{
    [SerializeField] private InfoJoueur _infoJoueur;



    //Remet le compte de points à 0 sile joueur entre dans la zone de remise avec 5 points
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){

            if(_infoJoueur._nbPoints == 5){

                _infoJoueur._nbPoints = 0;
            }


        }
    }


}

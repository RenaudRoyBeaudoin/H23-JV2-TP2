using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Accueil : MonoBehaviour
{
    [SerializeField] private GestionnaireScene _gestionScenes;
    [SerializeField] InfoJoueur _infoJoueur;
    [SerializeField] InfoNiveau _infoNiveau;

    [SerializeField] private TMP_InputField _champNom;
    [SerializeField] private TMP_InputField _champParc;
    

     public void PartJeu(){
        if(_champNom.text !=""){


            //Enregistre le nom du jouer et du parc
            _infoJoueur._nomJoueur = _champNom.text;

            _infoNiveau._laNomDuParc = _champParc.text;


            //Remet le nombre de point à zéro
            _infoJoueur._nbPoints = 0;
            _infoJoueur._nbPointsTotals = 0;
            


            //Passe à la scène suivante
            _gestionScenes.SceneSuivante();
        }
     }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Accueil : MonoBehaviour
{
    
    [SerializeField] InfoJoueur _infoJoueur;
    [SerializeField] InfoNiveau _infoNiveau;

    [SerializeField] private TMP_InputField _champNom;
    [SerializeField] private TMP_InputField _champParc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void PartJeu(){
        if(_champNom.text !=""){

            _infoJoueur._nomJoueur = _champNom.text;

            _infoNiveau._laNomDuParc = _champParc.text;
            
            _gestionnaireScene.SceneSuivante();
    }
     }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Fin : MonoBehaviour
{
    [SerializeField] private GestionnaireScene _gestionScenes;
    [SerializeField] InfoJoueur _infoJoueur;
    [SerializeField] InfoNiveau _infoNiveau;

    [SerializeField] private TMP_Text _texteNombreDePoints;
    [SerializeField] private TMP_Text _texteNomDuParc;



    // Start is called before the first frame update
    void Start()
    {
        _texteNomDuParc.text = _infoNiveau._laNomDuParc;
        _texteNombreDePoints.text = _infoJoueur._nbPointsTotals.ToString();
    }


    public void RepartJeu(){
        
            //Remet le nombre de point à zéro
            _infoJoueur._nbPoints = 0;
            _infoJoueur._nbPointsTotals = 0;
            

            //Passe à la scène précédente
            _gestionScenes.Niv01();
     }

    public void RetourAccueil(){
        //Passe à la scène Accueil
        _gestionScenes.Accueil();
    }

}

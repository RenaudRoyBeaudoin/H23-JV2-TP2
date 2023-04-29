using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Niv01 : MonoBehaviour
{
   [SerializeField] private InfoJoueur _infoJoueur;
    [SerializeField] private InfoNiveau _infoNiveau;

    
    [SerializeField] private TMP_Text _texteNomDuJoueur;
    [SerializeField] private TMP_Text _texteNombreDePoints;
    [SerializeField] private TMP_Text _texteNomDuParc;


    // Start is called before the first frame update
    void Start()
    {
        _texteNomDuJoueur.text = _infoJoueur._nomJoueur;
        _texteNomDuParc.text = _infoNiveau._laNomDuParc;
    }

    // Update is called once per frame
    void Update()
    {
        VerifiePoints();
    }
    void VerifiePoints(){

        _texteNombreDePoints.text = _infoJoueur._nbPoints.ToString();

    }
}

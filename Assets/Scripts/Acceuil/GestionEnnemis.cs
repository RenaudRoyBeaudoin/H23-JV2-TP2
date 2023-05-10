using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEnnemis : MonoBehaviour
{

    [SerializeField] InfoNiveau _infoNiveau;

    //Dit de désactivé les ennemis dans le niveau suivant
    public void SansEnnemis(){
        _infoNiveau._avecEnnemis = false;
    }

    public void AvecEnnemis(){
        _infoNiveau._avecEnnemis = true;
    }
    
}

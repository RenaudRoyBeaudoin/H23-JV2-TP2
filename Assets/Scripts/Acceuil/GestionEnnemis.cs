using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEnnemis : MonoBehaviour
{

    [SerializeField] InfoNiveau _infoNiveau;


    public void SansEnnemis(){
        _infoNiveau._avecEnnemis = false;
    }

    
}

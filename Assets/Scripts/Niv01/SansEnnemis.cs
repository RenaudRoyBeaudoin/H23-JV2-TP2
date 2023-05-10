using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SansEnnemis : MonoBehaviour
{
    [SerializeField] InfoNiveau _infoNiveau;


    //Vient chercher mes ennemis
    [SerializeField] private GameObject[] _ennemis;

    // Start is called before the first frame update
    void Awake()
    {
        if(_infoNiveau._avecEnnemis == false){
            foreach(GameObject e in _ennemis){
                e.SetActive(false);
            }
        }  
    }

}

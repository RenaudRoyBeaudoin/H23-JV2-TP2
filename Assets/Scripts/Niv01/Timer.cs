using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private GestionnaireScene _gestionScenes;

    [SerializeField] private TMP_Text _timeText;

    [SerializeField] public float _tempsRestant;


    //Vient chercher mon canvas FinDeJeu
    [SerializeField] private GameObject _messageFin;

    //Vient chercher mes autres canvas
    [SerializeField] private GameObject[] _autresCanvas;


    // Update is called once per frame
    void Update()
    {
        CalculTemps();
        FinDeLaPartie();
    }



    private void CalculTemps(){
        _tempsRestant -= Time.deltaTime;
        AfficheTemps(_tempsRestant);
    }

    private void AfficheTemps(float temps){

        temps +=1;

        float minutes = Mathf.FloorToInt(temps/60);

        float secondes = Mathf.FloorToInt(temps % 60);


        _timeText.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }



    
    private void FinDeLaPartie(){
        if(_tempsRestant < 0){
            //Active mon message de fin
            _messageFin.SetActive(true);

            //Désactive les autres éléments de mon UI
            foreach(GameObject canvas in _autresCanvas){
                canvas.SetActive(false);
            }

            //Passe à la scène suivante dans trois secondes
            Invoke("SceneFin", 5);
        }
    }
    private void SceneFin(){
        _gestionScenes.SceneSuivante();
    }
}

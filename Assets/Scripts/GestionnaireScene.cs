using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionnaireScene : MonoBehaviour
{

    private int _sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void SceneSuivante(){
        if(_sceneIndex < SceneManager.sceneCountInBuildSettings - 1){
            SceneManager.LoadScene(_sceneIndex + 1);
        }
    }

    public void Accueil(){
        SceneManager.LoadScene("Acceuil");
    }

    public void Niv01(){
        SceneManager.LoadScene("Niv01");
    }
}
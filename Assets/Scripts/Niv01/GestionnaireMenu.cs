using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GestionnaireMenu : MonoBehaviour
{
    [SerializeField]private GameObject _menu;


    //Vient chercher le playerInput du joueur
    [SerializeField]private PlayerInput _playerInput;
    

    //Le menu apparait et le joueur ne peut plus bouger la caméra
    private void OnMenu(InputValue value){

        if(_menu.gameObject.activeSelf){
            _menu.SetActive(false);
            _playerInput.enabled = true;
        }
        else{
            _menu.SetActive(true);
            _playerInput.enabled = false;
        }
    }
    
    public void enablePlayerInput(){
        _playerInput.enabled = true;
    }


}

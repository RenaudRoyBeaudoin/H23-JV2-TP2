using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GestionnaireMenu : MonoBehaviour
{
    [SerializeField]private GameObject _menu;
    //[SerializeField]private PlayerInput _playerInput;

    //[SerializeField]private InputSystem;
    //[SerializeField]private bool _menuEstAffiche = false;

    private void OnMenu(InputValue value){

        if(_menu.gameObject.activeSelf){
            _menu.SetActive(false);
            //_playerInput.enabled = true;
        }
        else{
            _menu.SetActive(true);
            //_playerInput.enabled = false;
        }

        /*if(_menuEstAffiche == false){//ou if(_menu.gameObject.activeSelf){} else{} ou _menu.gameObject.activeInHierarchy; on peut faire avec ou sans le .gameObject
            _menu.SetActive(true);
            Debug.Log("allo");
            _menuEstAffiche = true;
        }
        else if(_menuEstAffiche == true){
            _menu.SetActive(false);
            _menuEstAffiche = false;
        }*/
    }
}

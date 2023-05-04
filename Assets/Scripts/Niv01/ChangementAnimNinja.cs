using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangementAnimNinja : MonoBehaviour
{
    // Le joueur
    [SerializeField] private GameObject _joueur;

     // Variable pour contenir la position du joueur
     private Vector3 _positionJoueur;

    // Variable pour faire référence à l'animateur du zombie
    private Animator _animator;


    [SerializeField] private NavMeshAgent _agent;


    void Start()
    {
        // Récupère le composant Animator
        _animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        BougerZombie();
    }


    void BougerZombie(){

        //position du joueur pour donner une destination à l'agent
        _positionJoueur = _joueur.transform.position;


        //destination de l'agent
        _agent.SetDestination(_positionJoueur);


        //valeur de la distance entre l'agent et le joueur
        
        float _distanceAgentCible = Vector3.Distance(_positionJoueur, transform.position);


        if(_distanceAgentCible < 2){
            
            bool oui = _animator.GetBool("Idle");
            if(oui== false){
              _agent.isStopped = true;
             _animator.SetBool("Idle", true);
           } 
           
            
            Debug.Log("crap");
            
        }
        else{
           
            
            //Invoke("RepartirAnimNinja", 2);
           
        }
    }

    private void RepartirAnimNinja(){
                _animator.SetBool("Idle", false);   
             _agent.isStopped = false;
    }
}

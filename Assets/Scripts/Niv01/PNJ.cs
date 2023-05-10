using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class PNJ : MonoBehaviour
{
    // Le joueur
        [SerializeField] private GameObject _joueur;

    //Zone de départ et de retour de l'agent
        [SerializeField] private GameObject _zone;

    // Variable pour contenir la position de la zone
        private Vector3 _positionZone;



    // Variable pour contenir la position du joueur
        private Vector3 _positionJoueur;

    // Variable pour faire référence à l'animateur du PNJ
        private Animator _animator;



    //Contient le navMesh
        [SerializeField] private NavMeshAgent _agent;



    //Variables pour le son
        [SerializeField] private AudioClip _sonLoser;
        private AudioSource audioSource;


    //Variable pour le timer
        [SerializeField] private Timer _timer;



    //Variable pour la distance maximale entre l'agent et le joueur
        [SerializeField] private float _distanceMax;



    void Start()
    {
        // Récupère le composant Animator et AudioSource
        _animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BougerPNJ();
    }


    void BougerPNJ(){

        //valeur de la distance entre l'agent et le joueur
        float _distanceAgentCible = Vector3.Distance(_positionJoueur, transform.position);


        //position du joueur pour donner une destination à l'agent
        _positionJoueur = _joueur.transform.position;


        //position de la zone pour donner une destination à l'agent
        _positionZone = _zone.transform.position;


        //destination de l'agent; Si le joueur est dans sa zone, l'agent le poursuit. Sinon, il revient au centre de sa zone
        if(_distanceAgentCible < _distanceMax){
            _agent.SetDestination(_positionJoueur);
        }
        else{
            _agent.SetDestination(_positionZone);
        }
        
        


        if(_distanceAgentCible < 2){
            _agent.isStopped = true;
             _animator.SetBool("Idle", true);
        }
        else{
            _animator.SetBool("Idle", false);   
            _agent.isStopped = false;
        }
    }

   
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            //Joue un son si le joueur est à moins de 2 mètres
            audioSource.clip = _sonLoser;
            audioSource.Play();

            Debug.Log("crap");

            //Fait perdre 2 secondes au joueur s'il entre en contact
            _timer._tempsRestant -= 2;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerPersonnage : MonoBehaviour
{
    [Tooltip("Vitesse de mouvement du personnage en m/s")]
    [SerializeField] private float _vitesseMouvement = 5f;
    [SerializeField] private float _forceSaut = 5f;
    [SerializeField] private float _multiplicateurCourse = 2f;
    [SerializeField] private float _sensibiliteSouris = 100f;

    //Ajouter les variables _listeBruitsPas, _sonSaut et _sonTombeAuSol ici
    [SerializeField] private AudioClip _sonSaut;
    [SerializeField] private AudioClip _sonTombeAuSol;
    [SerializeField] private AudioClip[] _listeBruitsPas;
    private Rigidbody _rb;
    private AudioSource audioSource;
    private bool isGrounded = true;
    private bool courir = false;
    private bool _sauter = false; //permet de vérifier si on a sauter
    private Vector2 movementInput;
    private Vector2 mouseDelta;

    // Variables pour les délais pour faire jouer les bruits de pas
    // À ajouter ici...
    private float delaiBruitPasCourse = 0.35f;
    private float delaiBruitPasMarche = 0.5f;
    private float compteurDeTempsBruitsPas = 0.0f;

    //Variables pour gérer la rotation avec la souris
    private float deltaRotationX;
    private float deltaRotationY;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        //La vitesse Final est la vitesse qui sera utilisé pour déplacer le personnage
        float _vitesseFinal = _vitesseMouvement;

        //Si le personnage est en train de courir
        if (courir)
        {   
            //On multiplie sa vitesse de mouvement
            _vitesseFinal = _vitesseMouvement * _multiplicateurCourse;
        }

        //Détermine la direction de mouvement selon les touches du clavier reçus
        float mouvementGaucheDroite = movementInput.x * _vitesseFinal;
        float mouvementAvantArriere = movementInput.y * _vitesseFinal;

        //Si il y a du mouvement
        if (mouvementGaucheDroite != 0 || mouvementAvantArriere != 0)
        {
            //Si le personnage est au sol
            if (isGrounded)
            {
                JouerBruitsDePas();
            }
        }

        // Convertir la vélocité locale en vélocité globale
        Vector3 globalVelocity = transform.TransformDirection(mouvementGaucheDroite,0,mouvementAvantArriere);

        // Définir la vélocité de l'objet
        _rb.velocity = new Vector3(globalVelocity.x, _rb.velocity.y, globalVelocity.z);
         
    }

    //Lorsqu'on appuie sur la touche "Shift"
    void OnCourir(InputValue value)
    {
        if(value.isPressed)
        {
            courir = true;
        }
        else
        {
            courir = false;
        }
    }

    //Lorsqu'on déplace la souris
    void OnLook(InputValue value)
    {
        //Delta représente la quantité de mouvement de la souris dans les deux axe (X et Y) depuis la dernière lecture
        Vector2 delta = value.Get<Vector2>();

        //Calcul la quantité de rotation à effectuer dans l'axe X et Y selon la sensibilité de la souris
        deltaRotationY = delta.x * _sensibiliteSouris * Time.fixedDeltaTime;
        deltaRotationX = delta.y * _sensibiliteSouris * Time.fixedDeltaTime;

        //Récupère l'orientation local du joueur
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        
        //Convertir une rotation de 0 à 360 degrés vers -180 à 180 degrés
        float rotationX = convertirRotationEn180Degres(currentRotation.x - deltaRotationX);

        //On limite la rotation entre -90 degrés et 90 degr.s afin d'.viter de faire un tour complet haut/bas
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        
        //Calcul la nouvelle rotation dans l'axe Y
        float rotationY = currentRotation.y + deltaRotationY;
        
        //On applique la rotation X et Y au composent transform de l'objet où se trouve ce script
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);

    }

    void OnSaut()
    {
        if (isGrounded)
        {
            _rb.AddForce(Vector3.up * _forceSaut, ForceMode.Impulse);
            isGrounded = false;

            _sauter = true;
            //Fait jouer le son du saut
            audioSource.clip = _sonSaut;
            audioSource.Play();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if(_sauter){
               //Fait jouer le son lorsqu'on tombe au sol
            audioSource.clip = _sonTombeAuSol;
            audioSource.Play(); 
            
            _sauter = false;
            }
            
        }
    }

    void JouerBruitsDePas()
    {
        // Incrémenter le compteur de temps
        compteurDeTempsBruitsPas += Time.deltaTime;
        
        //Initialise une variable qui va contenir le délai avant de jouer le son à nouveau
        float delai = 0;

        //Affecte le bon délai selon si le personne court ou pas
        if (courir)
        {
            delai = delaiBruitPasCourse;
        }
        else
        {
            delai = delaiBruitPasMarche;
        }

        // Vérifier si le délai est écoulé
        if (compteurDeTempsBruitsPas > delai)
        {   
            //Fait jouer un son aléatoire dans la liste de son de bruits de pas
            //Ajouter le script ici
            int randomIndex = Random.Range(0, _listeBruitsPas.Length);
            audioSource.clip = _listeBruitsPas[randomIndex];
            audioSource.Play();

            // Réinitialiser le compteur de temps
            compteurDeTempsBruitsPas = 0.0f;
        }

        
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    //Pour convertir une rotation de 0 à 360 degrés vers -180 à 180 degrés
    private float convertirRotationEn180Degres(float valeurRotation)
    {
        float rotationFinale;

        if(valeurRotation > 180f) {
            rotationFinale = valeurRotation - 360f;
        }
        else {
            rotationFinale = valeurRotation;
        }

        return rotationFinale;
    }
}

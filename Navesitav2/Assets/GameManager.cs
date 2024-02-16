using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private Rigidbody rbNave;
    public GameObject bala;

    private InputAction actionMove;
   
   // public TMP_Text txtpuntaje;
   // public TMP_Text txtvidas;
    //public GameObject HUD;
    //public GameObject Menu;
   // public GameObject GameOver;
    public int puntaje;
    public int vidas = 5;
    
    public float speed;
    //public float limiteX = 5;
    //public float limiteZ = 2;

    private bool ismoving;
    public GameObject obstaclepool;
    public GameObject ObstacleSpawner;


    public bool IsPlaying=false;



    // Start is called before the first frame update
    private void Start()
    {

       // cameraPlayer.SetActive(false);
        
        //cameraMenu.SetActive(true);

        ObstacleSpawner.SetActive(false);
      //  HUD.SetActive(false);
       obstaclepool.SetActive(false);
        PlayerInput playerActions = GetComponent<PlayerInput>();

        rbNave = GetComponent<Rigidbody>();
        actionMove = playerActions.actions.FindAction("LeftStick");
    }
    public void empezar()
    {
        IsPlaying = true;
        obstaclepool.SetActive(true) ;
        ObstacleSpawner.SetActive(true);
        //Menu.SetActive(false);

     //   GameOver.SetActive(false);
        //cameraMenu.SetActive(false);

 



    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.SetActive(false);
            vidas--;
           // txtvidas.text = vidas.ToString();

        }
    }
    

    public void PuntajeAumenta()
    {
        puntaje++;
        //txtpuntaje.text = puntaje.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (IsPlaying)
        {
            
            obstaclepool.SetActive(true);
            ObstacleSpawner.SetActive(true);
            // HUD.SetActive(true);
            Vector2 direction = actionMove.ReadValue<Vector2>().normalized;

            float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg + 90f;

            ismoving = Convert.ToBoolean(direction.magnitude);

            if (ismoving)
            {
                rbNave.AddRelativeForce(Vector3.forward * Time.deltaTime * speed);
                rbNave.rotation = Quaternion.Euler(0, angle, 0);
            }

            float worldHeight = Camera.main.orthographicSize * 2.0f;
            float worldWidth = worldHeight * Camera.main.aspect;

            if ((rbNave.transform.position.x >= (worldWidth / 2) || rbNave.transform.position.z >= (worldHeight / 2))
                || ((rbNave.transform.position.x <= -(worldWidth / 2) || rbNave.transform.position.z <= -(worldHeight / 2))))
            {
                rbNave.gameObject.SetActive(false);
                obstaclepool.gameObject.SetActive(false);
                IsPlaying = false;
            }
        }
        
    }

    public void FixedUpdate()
    {
        /*
        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight * Camera.main.aspect;

        //print(worldWidth / 2);
        //print(worldHeight / 2);

        rbNave.position = new Vector3(Math.Clamp(rbNave.position.x, -worldWidth / 2, worldWidth / 2), rbNave.position.y, Math.Clamp(rbNave.position.z, -worldHeight / 2, worldHeight / 2));
        */
    }

    public void onAttackTap()
    {    
        Instantiate(bala, transform.position, transform.rotation);
    }
}
    
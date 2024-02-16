using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class bala : MonoBehaviour
{
    public float speedBala = 20;
  
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speedBala, ForceMode.Impulse);
    }
    

    // Update is called once per frame
    void Update()
    {
        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight * Camera.main.aspect;

        if ((transform.transform.position.x >= (worldWidth / 2) || transform.transform.position.z >= (worldHeight / 2))
            || ((transform.position.x <= -(worldWidth / 2) || transform.transform.position.z <= -(worldHeight / 2))))
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
  

            GameManager gm = FindObjectOfType<GameManager>();
            gm.PuntajeAumenta();
        }
    }
 

}

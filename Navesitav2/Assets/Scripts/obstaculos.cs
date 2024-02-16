using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculos : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public float speed = 100;
    public float limiteX = 9;
    public float limiteZ = 6;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 15)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.x < -15)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.z > 7)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.z < -7)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.SetActive(false);
        }
    }

}

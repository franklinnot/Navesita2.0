using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearObstaculos : MonoBehaviour
{
    private float LimiteX=11;
    private float LimiteZ=6;
    public GameObject player;
    public float speed=2;

    public static Vector3[] a;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generaAsteroides", 0.5f, 2f);
        InvokeRepeating("aumentodificultad", 5, 5);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void generaAsteroides()
    {
        a = new Vector3[4];
        Vector3 randomSpawn = new Vector3(Random.Range(-12,12),0,LimiteZ);
        Vector3 randomSpawn1 = new Vector3(Random.Range(-12, 12), 0, -5);
        Vector3 randomSpawn2 = new Vector3(9, 0, Random.Range(-6, 6));
        Vector3 randomSpawn3 = new Vector3(-9, 0, Random.Range(-6, 6));
        a[0] =randomSpawn;
        a[1] = randomSpawn1;
        a[2] = randomSpawn2;
        a[3] = randomSpawn3;
        
        int indice1 = Random.Range(0, a.Length);
        float rangoX = Random.Range(-LimiteX, LimiteX);
        float rangoZ = Random.Range(-LimiteZ, LimiteZ);
        
        Vector3 posicionAsteroides1 = new Vector3(rangoZ, 0, -LimiteZ);
        GameObject obstacle = ObstaclePool.Instance.RequestObstacle();
        obstacle.transform.position = a[indice1];
        obstacle.transform.LookAt(player.transform);
        obstacle.GetComponent<Rigidbody>().velocity=(obstacle.transform.forward * speed);
    }


    void aumentodificultad()
    {
        if (speed < 10)
        {
            speed = speed + 1;
            Debug.Log("VELOCIDAD AUMENTADA");
        }
       
    }
}

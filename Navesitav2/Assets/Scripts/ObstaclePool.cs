
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private List<GameObject> ObstacleList;
    public GameObject player;
    private static ObstaclePool instance;

    public static ObstaclePool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        AddObstaclesToPool(poolSize);
    }


    private void AddObstaclesToPool(int amount)
    {
        for (int i = 1; i < amount; i++)
        {
            GameObject obstacle = Instantiate(ObstaclePrefab);
            obstacle.SetActive(false);
            ObstacleList.Add(obstacle);
            obstacle.transform.parent = transform;

        }
    }


    public GameObject RequestObstacle()
    {
        for(int i = 0; i < ObstacleList.Count; i++)
        {
            if (!ObstacleList[i].activeSelf)
            {
                ObstacleList[i].SetActive(true);
                
                return ObstacleList[i];
            }
        }
        return null;
    } 
}

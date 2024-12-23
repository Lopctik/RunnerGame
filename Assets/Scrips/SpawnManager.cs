using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagmer : MonoBehaviour
{
    public GameObject[] obstacles;
    private int obstIndex;
    // public PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 1.5f);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (!PlayerController.GAMEOVER)
        {
            Vector3 pos = new Vector3(35, 0, 0);
            obstIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstIndex], pos, obstacles[obstIndex].transform.rotation);           
        }

    }

}

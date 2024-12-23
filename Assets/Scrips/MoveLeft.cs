using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20;
    public int downRangeX = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.GAMEOVER)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < downRangeX)
            Destroy(gameObject);
    }

}

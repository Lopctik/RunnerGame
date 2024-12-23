using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackround : MonoBehaviour
{

    private float _width;
    private Vector3 _startPos;

    // Start is called before the first frame update
    private void Start()
    {
        _startPos = transform.position;
        _width = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startPos.x - _width)
        {
            transform.position = _startPos;
        }
        
    }
}

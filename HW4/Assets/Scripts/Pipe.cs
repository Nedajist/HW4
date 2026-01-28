using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] float Speed = 2.5f;
    [SerializeField] Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = (Vector2.left * Speed);
        if (transform.position.x < -10)
        {
            Destroy(transform.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] int _jumpHeight;
    [SerializeField] SpriteRenderer bird_sprite;

    public delegate void BirdDelegate();
    public event BirdDelegate BirdPointAdded;
    public event BirdDelegate BirdJumped;
    public event BirdDelegate BirdDied;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void ResetVelocity()
    {
        _rigidbody2D.velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = (Vector2.up * _jumpHeight);
            bird_sprite.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
            BirdJumped.Invoke();
        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdDied.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdPointAdded.Invoke();
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    //private float currspeed;
    public float ballSpeed = 100;
    public float hitCoeff = 1.05f;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_rb.AddForce(Vector2.left * ballSpeed);
        StartCoroutine(nameof(Launch));
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Paddle"))
        {
            Debug.Log("ouch a paddle");
            //_rb.velocity = new Vector2(-_rb.velocity.x*hitCoeff,_rb.velocity.y);
        }
        if (other.collider.CompareTag("Player1Goal"))
        {
            
        }
        if (other.collider.CompareTag("Player2Goal"))
        {
            
        }
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("wham");
        //_rb.AddForce(Vector2.left* (Mathf.Floor(Random.(0,1)))?-1:1);
        if (Random.Range(0f,1f)>.5f)
        {
            _rb.AddForce(new Vector2(-100f,Random.Range(-50f,50f)));
        }
        else
        {
            _rb.AddForce(new Vector2(100f,Random.Range(-50f,50f)));
        }

        Random.Range(0, 1);
        //Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));

    }
}

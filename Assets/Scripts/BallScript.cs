
using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    //private float currspeed;
    public float ballSpeed = 100;
    public float hitCoeff = 1.05f;

    public AudioSource blip;
    public AudioSource score;

    private GameController gc;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(Launch));
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Paddle"))
        {
            blip.pitch = .75f;
            blip.Play();
        }
        if (other.collider.CompareTag("Player1Goal"))
        {
            score.Play();
            gc.player2Score++;
            gc.LevelUp(2);
            Reset();
        }
        if (other.collider.CompareTag("Player2Goal"))
        {
            score.Play();
            gc.player1Score++;
            gc.LevelUp(1);
            Reset();
        }
        if (other.collider.CompareTag("Wall"))
        {
            blip.pitch = 1f;
            blip.Play();
        }
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("wham");
        //_rb.AddForce(Vector2.left* (Mathf.Floor(Random.(0,1)))?-1:1);
        if (Random.Range(0f,1f)>.5f)
        {
            _rb.AddForce(new Vector2(-200f,Random.Range(-50f,50f)));
        }
        else
        {
            _rb.AddForce(new Vector2(200f,Random.Range(-50f,50f)));
        }

        Random.Range(0, 1);
        //Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));

    }

    void Reset()
    {
        _rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
        StartCoroutine(nameof(Launch));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    private float     yPos;
    public float      paddleSpeed = .01f;
    public float      topWall, bottomWall;

    public int player;
    void Start()
    {
        Camera MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector2 screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        topWall = screenBounds.y-GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        bottomWall = -topWall;
    }

    void Update() {
        if (player == 1)
        {
            float clampy = Mathf.Clamp(transform.localPosition.y+Input.GetAxisRaw("Vertical1") * paddleSpeed,-topWall,topWall);
            transform.localPosition = new Vector3(transform.localPosition.x,clampy,transform.localPosition.z);
        }
        if (player == 2)
        {
            float clampy = Mathf.Clamp(transform.localPosition.y+Input.GetAxisRaw("Vertical2") * paddleSpeed,-topWall,topWall);
            transform.localPosition = new Vector3(transform.localPosition.x,clampy,transform.localPosition.z);
        }
    }
}


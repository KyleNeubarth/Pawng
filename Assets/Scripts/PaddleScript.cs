using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    private float     yPos;
    public float      paddleSpeed = .02f;
    public float      topWall, bottomWall;

    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector2 screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        //Debug.Log(screenBounds);

        topWall = screenBounds.y-GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        bottomWall = -topWall;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (yPos > bottomWall) {
                yPos -= paddleSpeed;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            if (yPos < topWall) {
                yPos += paddleSpeed;
            }
        }

        transform.localPosition = new Vector3(transform.position.x, yPos, 0);
    }
}


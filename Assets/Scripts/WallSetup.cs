using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector2 screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        //Debug.Log(screenBounds);

        EdgeCollider2D Left = transform.GetChild(0).GetComponent<EdgeCollider2D>();
        EdgeCollider2D Right = transform.GetChild(1).GetComponent<EdgeCollider2D>();
        EdgeCollider2D Up = transform.GetChild(2).GetComponent<EdgeCollider2D>();
        EdgeCollider2D Down = transform.GetChild(3).GetComponent<EdgeCollider2D>();

        Vector2[] points;

        points = Left.points;
        
        points[0] = new Vector2(-screenBounds.x,screenBounds.y);
        points[1] = new Vector2(-screenBounds.x,-screenBounds.y);

        Left.points = points;

        points = Right.points;
        
        points[0] = new Vector2(screenBounds.x,screenBounds.y);
        points[1] = new Vector2(screenBounds.x,-screenBounds.y);

        Right.points = points;
        
        points = Up.points;
        
        points[0] = new Vector2(-screenBounds.x,screenBounds.y);
        points[1] = new Vector2(screenBounds.x,screenBounds.y);

        Up.points = points;
        
        points = Down.points;
        
        points[0] = new Vector2(-screenBounds.x,-screenBounds.y);
        points[1] = new Vector2(screenBounds.x,-screenBounds.y);

        Down.points = points;

        GameObject player1 = GameObject.Find("Player1");
        GameObject player2 = GameObject.Find("Player2");
        
        player1.transform.position = new Vector3(-screenBounds.x+.25f,0,0);
        player2.transform.position = new Vector3(screenBounds.x-.25f,0,0);
        //I made an arbitrary change here to test git!

        //this didn't work
        //Down.points[0] = new Vector2(-screenBounds.x,-screenBounds.y);
        //Down.points[1] = new Vector2(screenBounds.x,-screenBounds.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script dedicated to figuring out why the hell I can't update edgecollider points
// >:(
public class MoveMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EdgeCollider2D e = GetComponent<EdgeCollider2D>();
        Vector2[] points = e.points;
        points[0] = new Vector2(100,100);
        points[1] = new Vector2(-100,-100);
        e.points = points;

    }

    private void Update()
    {
        //EdgeCollider2D e = GetComponent<EdgeCollider2D>();
        //e.points[0] = new Vector2(100,100);
        //e.points[1] = new Vector2(-100,-100);
    }
}

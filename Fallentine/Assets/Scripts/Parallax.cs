using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour // a background that seamlessly scrolls at a different speed than the player
{
    public float maxHeight; // the max height that the background should reach before it is reset
    public Vector2 origin; // the point that the background should go to to be reset

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= maxHeight)
        {
            transform.position = origin;
        }
    }
}

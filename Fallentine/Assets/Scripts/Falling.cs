using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [Range(-10, 10)]
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}

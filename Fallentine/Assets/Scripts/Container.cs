using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Actor, IDestroyable
{
    public GameObject content; // The contents of the container

    public void Update()
    {
        content.transform.position = transform.position;
    }

    public void DestroySelf()
    {
        content.SetActive(true);
        gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("arrow") || other.CompareTag("explosion"))
        {
            PlaySound();
            DestroySelf();
        }
    }
}

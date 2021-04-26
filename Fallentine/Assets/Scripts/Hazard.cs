using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : Actor, IDestroyable // Hazards damage the player and can only be destroyed by explosions
{
    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("explosion"))
        {
            DestroySelf();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IDestroyable // Explosions persist for a limited amount of time, damaging a variety of objects
{
    [Range(0, 10)]
    public float duration; // The duration of the explosion

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", duration);
    }
}

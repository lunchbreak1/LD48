using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : Actor, IDestroyable // Balloons carry passengers and can be destroyed by arrows or explosions
{
    public GameObject passenger;
    public float delay;
    Falling falling;
    Enemy enemy;
    Player player;

    public void Start()
    {
        base.Start();
        enemy = passenger.GetComponent<Enemy>();
        falling = passenger.GetComponent<Falling>();
        player = FindObjectOfType<Player>();
    }

    public void DestroySelf()
    {
        PlaySound();
        falling.speed *= -1;
        enemy.label = "down";
        Invoke("DisablePassenger", delay);
        gameObject.SetActive(false);
    }

    void DisablePassenger() //Remove the passenger from the game after a few seconds
    {
        passenger.SetActive(false);
        player.goons++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("arrow") || other.CompareTag("explosion"))
        {
            //Debug.Log(clip.ToString());
            //audio.PlayOneShot(clip, .5f);
            DestroySelf();
        }
    }
}

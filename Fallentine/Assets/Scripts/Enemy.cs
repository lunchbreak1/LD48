using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Enemy : Actor, IDestroyable // Enemies damage the player and can be destroyed by arrows or explosions
{
    public SpriteResolver spriteResolver;
    public string label = "up";
    Player player;

    public void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
    }


    public void DestroySelf()
    {
        gameObject.SetActive(false);
        player.goons++;
    }

    public void Update()
    {
        spriteResolver.SetCategoryAndLabel("goon", label);
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

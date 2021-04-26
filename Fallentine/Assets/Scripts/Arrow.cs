using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Arrow : Actor, IDestroyable
{
    [Range(0, 10)]
    public float speed; // The speed the arrow travels at
    public Vector2 movement; // The movement path of the arrow
    public SpriteResolver spriteResolver;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(movement * Time.deltaTime * speed);
    }

    public void SetMovement(Vector2 newMovement) // set the arrow's movement
    {
        movement = newMovement;
        spriteResolver.SetCategoryAndLabel("arrow", LabelGenerator.GetLabel(movement));
    }

    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroySelf();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroySelf();
    }
}

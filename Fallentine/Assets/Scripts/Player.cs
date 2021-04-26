using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteResolver))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Player : Actor // The player character
{
    public int hearts; // the number of hearts the player has collected
    public int goons; // the number of goons the player has brought down

    [Range(0, 10)]
    public float speed, // the movement speed of the player character
                 arrowOffset, // how far away the arrow will spawn
                blinkDuration, blinkSpeed; //the speed and duration for which the character will blink when damaged

    public bool loaded, // true when the player is ready to fire an arrow
    blink = false; // when the character is blinking, they are invincible and cannot lose hearts

   private string category = "ready", // The category of sprite used by the SpriteLibrary
                  label = "south"; // The label of the sprite used by the SpriteLibrary

    private Vector2 movementVector; // the player's movement vector
    private Vector3 orientation; // the arrow's movement vector

    public GameObject arrowObj; // the arrow gameObject

    Arrow arrow; // an arrow fired by the player

    SpriteResolver spriteResolver; // a component that obtains sprites based on a category and label

    SpriteRenderer sprite; // the character's current sprite

    public AudioClip shootClip, pickUpClip, damagedClip;

    void Start() // Start is called before the first frame update
    {
        base.Start();
        sprite = GetComponent<SpriteRenderer>();
        spriteResolver = GetComponent<SpriteResolver>();

        arrow = arrowObj.GetComponent<Arrow>();
        orientation = new Vector3(0, -arrowOffset, 1);
    }

    
    void Update() // Update is called once per frame
    {
        loaded = arrowObj.activeSelf ? false : true;

        category = GetCategory();

        if (movementVector.magnitude > 0)
        {
            orientation = new Vector3(arrowOffset * movementVector.x, arrowOffset * movementVector.y, -1);
            label = LabelGenerator.GetLabel(orientation);
        }
        spriteResolver.SetCategoryAndLabel(category, label);
        
    }

    void FixedUpdate() //set the force and rotation based on user input (these are physics calculations)
    {
        transform.Translate(movementVector * Time.deltaTime * speed);
    }

    private void OnMove(InputValue movementValue) //get the value of the user input
    {
        movementVector = movementValue.Get<Vector2>();
    }

    private void OnFire() // fire an arrow
    {
        if(loaded)
        {
            arrow.transform.position = (transform.position + orientation);
            arrow.SetMovement(orientation);
            arrowObj.SetActive(true);
            audio.PlayOneShot(shootClip, .5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // pick up or drop a heart when colliding with an object
    {
        GameObject other = collision.gameObject;

        if(other.CompareTag("heart"))
        {
            hearts++;
            Destroy(other);
            audio.PlayOneShot(pickUpClip, .5f);
        }

        if (hearts > 0 && !blink && (other.CompareTag("hazard") || 
                           other.CompareTag("enemy") || 
                           other.CompareTag("explosion")))
        {
            hearts--;
            blink = true;
            Blink();
            Invoke("EndBlink", blinkDuration);
            audio.PlayOneShot(damagedClip, .5f);
        }
    }

    private string GetCategory() // determine the sprite category based on whether or not the player can shoot
    {
        string category = loaded ? "ready" : "loading";
        return category;
    }

    void Blink() // blink when the player has temporary invincibility
    {
        if (sprite.enabled)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }
        Invoke("Blink", blinkSpeed);
    }

    void EndBlink() // end temporary invincibility
    {
        CancelInvoke();
        blink = false;
        sprite.enabled = true;
    }




}

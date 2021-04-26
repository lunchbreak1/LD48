using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //public GameObject playerObj;
    public Player player; // The Player Component
    Text text; // The text displayed by this gameObject
    // Start is called before the first frame update
    void Start()
    {
        //player = playerObj.GetComponent<Player>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Hearts: " + player.hearts;
    }
}

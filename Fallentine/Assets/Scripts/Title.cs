using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour //This script will show "How To Play" when the 'H' button is pressed
{
    // Start is called before the first frame update
    public GameObject logo;
    public GameObject help;
    void OnHelp()
    {
        logo.SetActive(false);
        help.SetActive(true);
    }
}

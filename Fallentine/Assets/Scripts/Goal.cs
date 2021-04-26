using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : Actor // the goal will end the game and take the player to the victory screen
{
    public GameObject stage;
    public GameObject victory;

    Player player;
    Victory victoryComponent;

    void Start()
    {
        base.Start();
        victoryComponent = victory.GetComponent<Victory>();
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("player"))
        {
            victoryComponent.hearts = player.hearts;
            victoryComponent.goons = player.goons;
            //SceneManager.LoadScene("victory");
            stage.SetActive(false);
            victory.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOvers : MonoBehaviour
{
    public KeyCode EndCode;
    public timer tomer;
    public Player1 player1;
    public Player2 player2;
    public Text GameOver;
    public string Winner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tomer.cntdnw <= 0)
        {
            Winner = "Draw!";
            GameOver.text = (Winner);
            StartCoroutine(WaitingForTheNight());
            if(Input.GetKey(EndCode))
                {SceneManager.LoadScene("SampleScene");}
        }
        else if(player1.currentHealth <= 0)
        {
            Winner ="Player 2 Wins!";
            GameOver.text = (Winner);
            StartCoroutine(WaitingForTheNight());
            if(Input.GetKey(EndCode))
                {SceneManager.LoadScene("SampleScene");}
        }
        else if(player2.currentHealth <= 0)
        {
            Winner = ("Player 1 Wins!");
            GameOver.text = (Winner);
            StartCoroutine(WaitingForTheNight());
            if(Input.GetKey(EndCode))
                {SceneManager.LoadScene("SampleScene");}
        }
    }

    IEnumerator WaitingForTheNight()
    {
        yield return new WaitForSeconds(5);
        Winner = ("Press space to restart");
        GameOver.text = (Winner);
    }
}

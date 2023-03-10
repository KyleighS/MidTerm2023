using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject victoryUI;

    void Start()
    {
        gameEnded = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameEnded = true;
        victoryUI.SetActive(true);
    }
}

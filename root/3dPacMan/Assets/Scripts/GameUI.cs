////////////////////////////////////////////////
///Assignment/Lab/Project: PacMan
/////Name: Wyatt Murray
/////Section: SGD285.4147
/////Instructor: Aurore Locklear
/////Date: 1/21/24
////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Search;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{

    public int coins;
    public int lives = 3;
    public int maxCoins;

    //the counters for thier text component
    public TextMeshProUGUI lifeCounter;
    public TextMeshProUGUI coinCounter;

    //events for other items to hook up to
    public UnityEvent Win = new();
    public UnityEvent Lose = new();

    private void Update()
    {
        lifeCounter.text = $"Lives\n{lives} / 3";
        lifeCounter.text = $"Coins\n{coins}";
    }

    public void ReduceLife()
    {
        lives--;
        if (coins == 0)
        {
            //you lose
            Lose.Invoke();
        }
    }

    public void AddCoin()
    {
        coins++;
        if (coins == maxCoins) 
        {
            //you win
            Win.Invoke();
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("gameScene");
    }

}

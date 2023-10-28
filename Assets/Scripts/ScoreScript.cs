using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public int playerHealth = 3;
    public Text healthText;
    public PlayerScript player;
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }
    public void Health()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerHealth--;
        healthText.text = playerHealth.ToString();
        if (playerHealth == 0)
        {
            Destroy(player);
            SceneManager.LoadScene("GameOver");
        }
    }
}

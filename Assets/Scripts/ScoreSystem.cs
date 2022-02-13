using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int startScore = 10;
    [SerializeField] private TextMeshProUGUI followerText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private int startGold = 20;

    public int Gold { get; set; }

    private int score;

    private void Awake()
    {
        score = startScore;
        Gold = startGold;
        followerText.text = "Followers: " + score;
        goldText.text = "Gold: " + Gold;
    }

    private void Update()
    {
        goldText.text = "Gold: " + Gold;
    }

    public void DecreaseScore()
    {
        score--;
        followerText.text = "Followers: " + score;
        if (score <= 0)
        {
            // end the game
            Time.timeScale = 0;
            HUD.LosePanel.ToggleVisible();
        }
    }
}

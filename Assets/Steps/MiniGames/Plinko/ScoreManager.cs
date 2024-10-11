using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int yellowScore = 0;
    public int redScore = 0;
    public int blueScore = 0;
    public int greenScore = 0;

    public TMP_Text yellowScoreText;
    public TMP_Text redScoreText;
    public TMP_Text blueScoreText;
    public TMP_Text greenScoreText;

    // Call this method when a ball hits a goal to update the score based on the tag
    public void AddPoints(string tag, int points)
    {
        switch (tag)
        {
            case "yellow":
                yellowScore += points;
                yellowScoreText.text = $"yellow: {yellowScore}";
                break;
            case "red":
                redScore += points;
                redScoreText.text = $"red: {redScore}";
                break;
            case "blue":
                blueScore += points;
                blueScoreText.text = $"blue: {blueScore}";
                break;
            case "green":
                greenScore += points;
                greenScoreText.text = $"green: {greenScore}";
                break;
        }
    }
}

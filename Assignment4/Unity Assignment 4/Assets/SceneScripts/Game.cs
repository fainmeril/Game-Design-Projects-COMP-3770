using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int CurrentHighscore;

    public GameObject CurrentBrush;
    public GameObject CurrentHighscoreTextObject;

    private TMPro.TextMeshProUGUI CurrentHighscoreText;

    private void Start()
    {
        CurrentHighscoreText = CurrentHighscoreTextObject.GetComponent<TMPro.TextMeshProUGUI>();
        UpdateHighscore(0);
        
    }

    public void UpdateHighscore(int score)
    {
        CurrentHighscore = score;
        CurrentHighscoreText.text = score.ToString();
    }

}

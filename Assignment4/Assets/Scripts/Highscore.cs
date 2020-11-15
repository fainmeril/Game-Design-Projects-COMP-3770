using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CurrentHighscore;
    public void UpdateHighscore(int score)
    {
        CurrentHighscore.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject GameObject;
    private Game GameScriptInstance;

    void Start()
    {
        GameScriptInstance = GameObject.GetComponent<Game>();
    }

    public void ExitButton()
    {
        SaveToPlayerPrefs();
        SceneManager.LoadScene(0);
    }

    private void SaveToPlayerPrefs()
    {
        if(!PlayerPrefs.HasKey("Paint_Highscore"))
        {
            Debug.Log("Has no Key in Registry...");
            PlayerPrefs.SetInt("Paint_Highscore", GameScriptInstance.CurrentHighscore);
        }
        else
        {
            if(PlayerPrefs.GetInt("Paint_Highscore") < GameScriptInstance.CurrentHighscore)
            {
                Debug.Log("Has Key in Registry...");
                Debug.Log(PlayerPrefs.GetInt("Paint_Highscore") + " < " + GameScriptInstance.CurrentHighscore);

                PlayerPrefs.SetInt("Paint_Highscore", GameScriptInstance.CurrentHighscore);
            }
        }

        Debug.Log("Starting Save...");
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }
}

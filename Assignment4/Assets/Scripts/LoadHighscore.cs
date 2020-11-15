using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHighscore : MonoBehaviour
{
    public string registryKey;

    // Start is called before the first frame update
    void Start()
    {
        SaveToPlayerPrefs();
    }

    private void SaveToPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey(registryKey))
        {
            Debug.Log("Has no Key in Registry...");
        }
        else
        {
            Debug.Log("Has Key in Registry...");
            Debug.Log(PlayerPrefs.GetInt(registryKey));
            this.gameObject.GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt(registryKey).ToString();
        }
    }
}

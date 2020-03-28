using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    public GameObject[] levels;
   // public TextMeshProUGUI saveLevel, nowLevel;

    void Update()
    {
        for (int i = 0; i <=PlayerPrefs.GetInt("saveLevel"); i++)
        {
            levels[i].SetActive(true);
        }
       // saveLevel.text = PlayerPrefs.GetInt("saveLevel").ToString();
       // nowLevel.text = PlayerPrefs.GetInt("Level").ToString();
    }
}

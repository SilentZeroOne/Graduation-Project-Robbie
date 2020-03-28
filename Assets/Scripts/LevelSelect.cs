using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.SetString("nowLevel", "Level" + gameObject.name);
        PlayerPrefs.SetInt("Level", ToInt(gameObject.name));
        SceneManager.LoadScene(2);
        GameManager.InGame();
    }
    public static int ToInt(string str)
    {
        int result = default;
        if (str != null)
        {
            int.TryParse(str, out result);
        }
        return result;
    }
}

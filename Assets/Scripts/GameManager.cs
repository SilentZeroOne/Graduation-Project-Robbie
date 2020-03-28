using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    SceneFader fader;
    List<Orb> orbs;
    Door lockedDoor;


   
    public int deathNum;
    float gameTime;
    bool gameIsOver = false;
    bool isPause = false;
    bool isInMain = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        orbs = new List<Orb>();

        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (isInMain)
        {
            gameTime = 0;
            deathNum = 0;
            orbs.Clear();
            return;
        }
        if (gameIsOver||isPause)
            return;
        gameTime += Time.deltaTime;
        UIManager.UpdateTimeUI(gameTime);
        UIManager.UpdateDeathUI(instance.deathNum);
    }
    public static void RegisterOrb(Orb orb)
    {
        if (!instance.orbs.Contains(orb))
            instance.orbs.Add(orb);
        UIManager.UpdateOrbUI(instance.orbs.Count);
    }

    public static void PlayerDead()
    {
        instance.fader.FadeOut();
        instance.deathNum++;
        UIManager.UpdateDeathUI(instance.deathNum);
        instance.Invoke("RestartScense", 1.5f);
    }
    void RestartScense()
    {
        instance.orbs.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static  void RegisterScenseFader(SceneFader obj)
    {
        instance.fader = obj;
    }

    public static void RegisterDoor(Door door)
    {
        instance.lockedDoor = door;
    }
    public static void PlayerGrabbedOrb(Orb orb)
    {
        if (!instance.orbs.Contains(orb))
            return;
        instance.orbs.Remove(orb);
        UIManager.UpdateOrbUI(instance.orbs.Count);
        if (instance.orbs.Count == 0)
            instance.lockedDoor.Open();
    }
    public static void PlayerWon()
    {
        instance.SaveData();
        instance.gameIsOver = true;
        UIManager.DisplayGameOver();
        AudioManager.PlayWinAudio();
    }
    public static bool GameOver()
    {
        return instance.gameIsOver;
    }
    public static bool GamePause()
    {
        return instance.isPause;
    }
    public static void Pause()
    {
        instance.isPause = true;
    }
    public static void Resume()
    {
        instance.isPause = false;
    }
    public static void InMain()
    {
        instance.isInMain = true;
        instance.gameIsOver = false;
    }
    public static void InGame()
    {
        instance.isInMain = false;
    }
    public void SaveData()
    {
        if (PlayerPrefs.GetInt("Level") > PlayerPrefs.GetInt("saveLevel"))
        {
            PlayerPrefs.SetInt("saveLevel", PlayerPrefs.GetInt("Level"));
        }
        
    }
}

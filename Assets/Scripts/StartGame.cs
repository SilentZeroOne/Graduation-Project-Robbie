using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject resumeBtn;
    public GameObject pauseBtn;
    public  AudioMixer aduioMixer;

    private void Awake()
    {
       
    }
    public void StartIt()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.InGame();
    }
    public void Clear()
    {
        PlayerPrefs.DeleteAll();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        resumeBtn.SetActive(true);
        pauseBtn.SetActive(false);
        GameManager.Pause();
        
        Invoke("Pause", 0.3f);
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        resumeBtn.SetActive(false);
        pauseBtn.SetActive(true);
        GameManager.Resume();
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void SetVolume(float value)
    {
        aduioMixer.SetFloat("MusicVolume", value);
    }
    public void BackToMain()
    {
        GameManager.Resume();
        Time.timeScale = 1;
        GameManager.InMain();        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

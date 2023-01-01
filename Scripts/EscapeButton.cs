using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOver;
    public GameObject QuitScreen;
 
    private void Awake()
    {
        QuitScreen.SetActive(false);
        GameOver.SetActive(false);

    }
   
    void Update()
    {


        if (Input.GetKeyUp(KeyCode.Escape))
        {

            QuitScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ResumButton()
    {
        Time.timeScale = 1f;
        QuitScreen.SetActive(false);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameOver.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);

    }
    public void About()
    {
        SceneManager.LoadScene(2);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void quitButton()
    {
        Application.Quit();
    }
}

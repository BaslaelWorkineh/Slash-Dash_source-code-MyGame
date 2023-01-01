using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausescript : MonoBehaviour
{

    public GameObject PauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        PauseScreen.SetActive(false);
    }

    public void PauseButton()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;

    }
    public void ResumeButton()
    {
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

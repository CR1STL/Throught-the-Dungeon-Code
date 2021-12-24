using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Scene_Switcher : MonoBehaviour
{
    public void Main_Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Controls()
    {
        SceneManager.LoadScene(1);
    }
    public void About_Game()
    {
        SceneManager.LoadScene(2);
    }
    public void Authors()
    {
        SceneManager.LoadScene(3);
    }
    public void Play()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}
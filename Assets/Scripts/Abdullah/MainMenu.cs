using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;

    public void Start()
    {
        Panel.SetActive(false);
    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("ActualScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Panel.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        Panel.SetActive(false);
    }




}

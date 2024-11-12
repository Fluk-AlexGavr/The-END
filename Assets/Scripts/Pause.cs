using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject menu;

    public void Resume()
    {
        menu.SetActive(false);
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}

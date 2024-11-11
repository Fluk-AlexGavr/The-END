using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject thismenu;
    public void ChangeMenu()
    {
        thismenu.SetActive(false);
        menu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

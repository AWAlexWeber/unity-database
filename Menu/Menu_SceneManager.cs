using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_SceneManager : MonoBehaviour
{
    // Menu Manager that will load other menus
    public void menuNewGame() {
        SceneManager.LoadScene("Room Base Scene");
    }

    public void menuLoadGame() {

    }

    public void menuOptions() {

    }

    public void menuAbout() {

    }

    public void menuExit() {
        
    }
}

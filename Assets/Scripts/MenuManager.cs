using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject helpMenu;

    public void onPlayClick()
    {
        // Load the main game scene
        SceneManager.LoadScene("MainGame");
    }

    public void onHelpClick()
    {
        // Load the help menu
        helpMenu.SetActive(true);
    }

    public void onCloseHelpClick()
    {
        // Close the help menu
        helpMenu.SetActive(false);
    }
}

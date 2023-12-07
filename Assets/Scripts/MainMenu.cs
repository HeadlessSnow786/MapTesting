using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
  {
    // Load the next scene in the build order
    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
  }

  public void QuitGame()
  {
    // Quit the game
    Application.Quit();
  } 

  public void BackToMenu()
  {
    // Load the main menu
    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
  }
}

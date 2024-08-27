using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Include the SceneManagement namespace

public class RestartQuit : MonoBehaviour
{
    // Method to restart the game
    public void RestartGame()
    {
        // Reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Quits the application
        Application.Quit();

        // If you are running this in the Unity editor, this line will stop the play mode.
        // Remove this line or comment it out before building the final game.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

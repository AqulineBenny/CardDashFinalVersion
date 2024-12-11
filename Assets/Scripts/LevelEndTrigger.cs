using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class LevelEndTrigger : MonoBehaviour
{
    // Method called when the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has reached the end
        if (other.CompareTag("Player"))
        {
            // Load the next level (Level 2)
            LoadNextLevel();
        }
    }

    // Load the next scene (Level 2)
    void LoadNextLevel()
    {
        // Get the current scene index and increment it to load the next scene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if the next scene exists (if not, we could loop back to Level 1)
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("This is the last level.");// You could display a message or go back to Level 1, etc.
        }
    }
}

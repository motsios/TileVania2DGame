using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelDelayed = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelDelayed);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSeenIndex = currentSceneIndex + 1;
        if (nextSeenIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSeenIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSeenIndex);
    }
}

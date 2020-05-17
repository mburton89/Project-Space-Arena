using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void RestartScene()
    {
        StartCoroutine(LoadSceneCo(2f, SceneManager.GetActiveScene().buildIndex));
    }

    private IEnumerator LoadSceneCo(float secondsToDelay, int buildIndex)
    {
        yield return new WaitForSeconds(secondsToDelay);
        SceneManager.LoadScene(buildIndex);
    }
}

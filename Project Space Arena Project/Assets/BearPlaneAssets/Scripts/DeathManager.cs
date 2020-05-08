using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void HandleDeath()
    {
        StartCoroutine(HandleDeathCo());
    }

    private IEnumerator HandleDeathCo()
    {
        yield return new WaitForSeconds(2);
        Destroy(EnemySpawner.Instance.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

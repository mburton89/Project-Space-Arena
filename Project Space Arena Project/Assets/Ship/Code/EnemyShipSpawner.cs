using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;

    [SerializeField] GameObject _enemyPlane1Prefab;
    [SerializeField] GameObject _enemyPlane2Prefab;
    [SerializeField] Transform _spawnPosition1;
    [SerializeField] Transform _spawnPosition2;
    private int _enemyCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnEnemies();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CheckEnemyCount();
        }
    }
#endif

    void SpawnEnemies()
    {
        Instantiate(_enemyPlane1Prefab, _spawnPosition1.position, transform.rotation, transform);
        Instantiate(_enemyPlane2Prefab, _spawnPosition2.position, transform.rotation, transform);
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;       
    }

    public void CheckEnemyCount()
    {
        StartCoroutine(CheckEnemyCountCo());
    }

    private IEnumerator CheckEnemyCountCo()
    {
        yield return new WaitForSeconds(.5f);
        int enemyCount = FindObjectsOfType<EnemyShip>().Length;
        if (enemyCount <= 0)
        {
            SpawnEnemies();
        }
    }
}

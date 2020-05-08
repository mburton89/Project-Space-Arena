using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] Plane _enemyPlanePrefab;
    [SerializeField] List<Vector3> _spawnPositions;
    [SerializeField] List<GameObject> _scenarioPrefabs;
    [SerializeField] List<GameObject> _cloudGroupPrefabs;
    [SerializeField] private Vector3 _cloudSpawnPosition;
    private GameObject _currentScenario;
    private int _enemyCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies(int numberOfPlanes, Plane planeType)
    {
        for (int i = 0; i < numberOfPlanes; i++)
        {
            Instantiate(_enemyPlanePrefab, _spawnPositions[i], this.transform.rotation, this.transform);
        }
    }

    void SpawnEnemies()
    {
        int randomScenario = Random.Range(0, 2);
        if (randomScenario == 1)
        {
            SpawnRandomPlaneGroup();
        }
        else
        {
            SpawnRandomCloudGroup();
        }
    }

    public void CheckEnemyCount()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        print(enemyCount);

        if (enemyCount <= 0)
        {
            Destroy(_currentScenario);
            SpawnEnemies();
        }
    }

    void SpawnRandomCloudGroup()
    {
        int randomScenario = Random.Range(0, _cloudGroupPrefabs.Count);
        _currentScenario = Instantiate(_cloudGroupPrefabs[randomScenario], _cloudSpawnPosition, transform.rotation, transform);
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        print("SpawnRandomCloudGroup " + randomScenario);
    }

    void SpawnRandomPlaneGroup()
    {
        int randomScenario = Random.Range(0, 4);
        _currentScenario = Instantiate(_scenarioPrefabs[randomScenario], transform.position, transform.rotation, transform);
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        print("SpawnRandomPlaneGroup " + randomScenario);
    }
}

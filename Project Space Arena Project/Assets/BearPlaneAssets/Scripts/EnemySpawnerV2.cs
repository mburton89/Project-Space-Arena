using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerV2 : MonoBehaviour
{
    public static EnemySpawnerV2 Instance;

    [SerializeField] private List<Plane> _enemyPlanePrefabs;

    [SerializeField] private float _secondsBetweenSpawns;
    [SerializeField] private float _x;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(spawnPlanes());
    }

    void SpawnEnemies(int numberOfPlanes, Plane planeType)
    {

    }

    IEnumerator spawnPlanes()
    {
        yield return new WaitForSeconds(_secondsBetweenSpawns);
        float _y = Random.Range(_minY, _maxY);
        Vector3 spawnPosition = new Vector3(_x, _y, 0);
        int planePrefabIndex = Random.Range(0, 3);
        Instantiate(_enemyPlanePrefabs[planePrefabIndex], spawnPosition, this.transform.rotation, this.transform);
        StartCoroutine(spawnPlanes());
    }
}

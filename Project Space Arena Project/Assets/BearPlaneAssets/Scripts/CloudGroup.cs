using UnityEngine;

public class CloudGroup : MonoBehaviour
{
    private float _speed;
    private float _secondsToExist;
    private Vector3 _direction;

    private void Awake()
    {
        _speed = -6;
        _secondsToExist = 7.5f;
        _direction = new Vector3(_speed, 0, 0);
        Destroy(gameObject, _secondsToExist);
    }

    private void OnDestroy()
    {
        EnemySpawner.Instance.CheckEnemyCount();
    }

    void Update()
    {
        transform.Translate(_direction * Time.deltaTime);
    }
}

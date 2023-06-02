using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _timeToDestoy;


    private Transform[] _VectorSpawnpoints;
    private float _nextSpawnDelay;

    void Start()
    {
        _VectorSpawnpoints = new Transform[_pointContainer.childCount];

        for (int i = 0; i < _pointContainer.childCount; i++)
        {
            _VectorSpawnpoints[i] = _pointContainer.GetChild(i);
        }
    }

    private void Update()
    {
        if (Time.time > _nextSpawnDelay)
        {
            _nextSpawnDelay = Time.time + _spawnDelay;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomNumber = Random.Range(0, _VectorSpawnpoints.Length);

        Vector3 objectPosition = _VectorSpawnpoints[randomNumber].position;
        Enemy enemy = Instantiate(_enemyPrefab, objectPosition, Quaternion.identity);

        Destroy(enemy.gameObject, _timeToDestoy);
    }
}

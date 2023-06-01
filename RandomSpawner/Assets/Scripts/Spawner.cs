using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private GameObject _template;
    [SerializeField] private float _spawnDelay;

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
        GameObject gameObject = Instantiate(_template, objectPosition, Quaternion.identity);

        Destroy(gameObject, 1.5f);
    }
}

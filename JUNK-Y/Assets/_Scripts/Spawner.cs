using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junky
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabToSpawn;
        [SerializeField] private Transform _spawnPosition;

        public void Spawn()
        {
            Instantiate(_prefabToSpawn, _spawnPosition.position, Quaternion.identity);
        }
        public void Spawn(Vector3 spawnPosition)
        {
            Instantiate(_prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}

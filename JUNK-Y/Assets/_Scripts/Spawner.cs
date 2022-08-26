using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junky
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabToSpawn;
        [SerializeField] private Transform _spawnPosition;


        [ContextMenu("SpreadSpawn")]
        public void asdat()
        {
            SpreadSpawn(1f);
        }
        public void SetPrefabToSpawn(GameObject newPrefab)
        {
            _prefabToSpawn = newPrefab;
        }
        public void Spawn()
        {
            Instantiate(_prefabToSpawn, _spawnPosition.position, _spawnPosition.rotation);
        }
        public void Spawn(Vector3 spawnPosition)
        {
            Instantiate(_prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        public void SpreadSpawn(float spread)
        {
            for (int i = 0; i <5; i++)
            {
                var randomPosition = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
                Instantiate(_prefabToSpawn, _spawnPosition.position + randomPosition, _spawnPosition.rotation);
            }
        }
    }
}

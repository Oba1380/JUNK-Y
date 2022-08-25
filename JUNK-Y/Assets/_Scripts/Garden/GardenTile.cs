using UnityEngine;
using System;

namespace Junky.Garden
{
    public class GardenTile : MonoBehaviour
    {
        
        [SerializeField] private Spawner _spawner;
        private Plant _plant;
        private bool _isPlanted;

        public Action OnStartGrow;
        public void StartGrow()
        {
            if (_isPlanted) return;

            _spawner.Spawn();
            _isPlanted = true;

            OnStartGrow.Invoke();
        }

        public void SetPlant(Plant newPlant)
        {
            _plant = newPlant;
            _spawner.SetPrefabToSpawn(_plant.gameObject);
        }
    }
}
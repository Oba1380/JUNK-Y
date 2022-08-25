using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junky.Garden
{
    public class Garden : MonoBehaviour
    {
        [SerializeField] private GardenTile[] _gardenTiles;
        [SerializeField] private Plant _plant;
        [Range(0,100)][SerializeField] private int _percentForFullPlant;
        private int _plantedTiles;

        private void OnEnable()
        {
            foreach (var tile in _gardenTiles)
            {
                tile.OnStartGrow += TryToPlantAllTiles;
                tile.SetPlant(_plant);
            }
        }
        private void TryToPlantAllTiles()
        {
            _plantedTiles++;
            if((float)_plantedTiles/_gardenTiles.Length*100 >= _percentForFullPlant)
            {
                foreach (var tile in _gardenTiles)
                {
                    tile.StartGrow();
                }
            }
        }
        private void OnDisable()
        {
            foreach (var tile in _gardenTiles)
            {
                tile.OnStartGrow -= TryToPlantAllTiles;
            }
        }
    }
}

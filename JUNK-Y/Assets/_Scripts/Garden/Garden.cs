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
        private bool _isFullPlanted;
        private List<Planter> _planters = new List<Planter>(2);
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

                _isFullPlanted = true;
                foreach(var planter in _planters)
                {
                    RemovePlanter(planter);
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
        public void TryAddPlanter(GameObject potentialPlanter)
        {
            if (_isFullPlanted) return;
            var planter = potentialPlanter.GetComponent<Planter>();
            if (planter == null) return;

            _planters.Add(planter);
            planter.IsOnGarden = true;
        }
        public void TryRemovePlanter(GameObject potentialPlanter)
        {
            var planter = potentialPlanter.GetComponent<Planter>();
            if (planter == null) return;
            RemovePlanter(planter);
        }
        private void RemovePlanter(Planter planter)
        {
            _planters.Remove(planter);
            planter.IsOnGarden = false;
        }
    }
}

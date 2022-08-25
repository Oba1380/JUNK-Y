using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Junky.Garden
{
    public class Planter : MonoBehaviour
    {
        [SerializeField] private LayerMask _gardenTileLayer;
        [SerializeField] private SphereCollider _plantZone;
        [SerializeField] private UnityEvent _onPlant;

        List<GardenTile> _gardenTiles = new List<GardenTile>();


        [ContextMenu("PlantsSeed")]
        public void PlantsSeed()
        {
            var gardenTiles = FindGardenTiles();
            foreach(var gardenTile in gardenTiles)
            {
                gardenTile.StartGrow();
            }
            _onPlant?.Invoke();
        }
        private GardenTile[] FindGardenTiles()
        {
            RaycastHit[] results = new RaycastHit[12];
            Physics.SphereCastNonAlloc(
                _plantZone.transform.position, 
                _plantZone.radius, 
                Vector3.forward ,
                results,
                _plantZone.radius,
                _gardenTileLayer);

            foreach(var result in results)
            {
                if (result.collider == null) break;
                var resultObject = result.collider.gameObject;

                var gardenTile = resultObject.GetComponent<GardenTile>();
                if (gardenTile == null) continue;

                _gardenTiles.Add(gardenTile);
            }

            return _gardenTiles.ToArray();
        }
    }
}

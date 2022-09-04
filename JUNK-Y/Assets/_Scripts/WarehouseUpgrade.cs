using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Junky.Garbage;

namespace Junky.Upgrades
{
    public class WarehouseUpgrade : MonoBehaviour, IUpgrade
    {
        [SerializeField] private int _cubesChangeValue;
        private GarbageWarehouse _warehouse;
        private void Awake()
        {
            _warehouse = FindObjectOfType<GarbageWarehouse>();
        }
        public void Upgrade()
        {
            _warehouse.MaxCubes += _cubesChangeValue;
        }
    }
}

using Junky.Garbage;
using UnityEngine;

namespace Junky.Upgrades
{
    [RequireComponent(typeof(IUpgrade))]
    public class Upgrader : MonoBehaviour
    {
        [SerializeField] private int _cubesCost;
        private GarbageWarehouse _playerWarehouse;
        private IUpgrade _upgrader;
        private void Awake()
        {
            _upgrader = GetComponent<IUpgrade>();
            _playerWarehouse = FindObjectOfType<GarbageWarehouse>();
        }
        public void TryUpgrade()
        {
            if (_cubesCost <= _playerWarehouse.GetCubesCount())
            {
                _playerWarehouse.RemoveGarbage(_cubesCost);
                _upgrader.Upgrade();
            }
        }
    }
}
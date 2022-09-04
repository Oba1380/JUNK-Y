using System;
using System.Collections.Generic;
using UnityEngine;

namespace Junky.Garbage
{
    public class GarbageWarehouse : MonoBehaviour
    {
        [SerializeField] private int _maxPoints;
        [SerializeField] private int _pointsToSpawnPressedGarbage;

        [SerializeField] private float _indentBetweenGarbagesVertical;
        [SerializeField] private float _indentBetweenGarbagesHorisontal;

        [SerializeField] private Transform _warehousePosition;
        [SerializeField] private PressedGarbage _pressedGarbage;

        private Stack<PressedGarbage> _collectedGarbage = new Stack<PressedGarbage>();

        private int _currentPoints;
        private int _garbageCount;
        public Stack<PressedGarbage> CollectedGarbage => _collectedGarbage;
        public int CurrentPoints
        {
            get => _currentPoints;
            set
            {
                _currentPoints = value > _maxPoints ? _maxPoints : value;
                _currentPoints = value < 0 ? 0 : _currentPoints;


                var lastGarbage = _collectedGarbage.Count > 0 ? _collectedGarbage.Peek().transform : _warehousePosition;
                OnPointsChange.Invoke(_currentPoints, lastGarbage);
            }
        }
        public Action<int, Transform> OnPointsChange;
        public void TakeGarbage(PressedGarbage garbage)
        {
            var pointsToAdd = garbage.Points;
            if (CurrentPoints != _maxPoints)
            {
                Destroy(garbage.gameObject);
                CurrentPoints += pointsToAdd;
            }

            var notUsedPoints = CurrentPoints -(_collectedGarbage.Count*_pointsToSpawnPressedGarbage);
            var garbageCreateCount = notUsedPoints / _pointsToSpawnPressedGarbage;
            for(int i = 0; i<garbageCreateCount;i++)
            {
                CreatePressedGarbage();
            }

        }
        private void CreatePressedGarbage()
        {
            var instantinatedGarbage = Instantiate(_pressedGarbage, transform.position, Quaternion.identity);

            PlaceGarbage(instantinatedGarbage);
            _collectedGarbage.Push(instantinatedGarbage);
            instantinatedGarbage.SetPickUpedState(true);
        }
        private void PlaceGarbage(PressedGarbage garbage)
        {
            Vector3 lastGarbagePosition;

            if (_collectedGarbage.Count <= 0) lastGarbagePosition = _warehousePosition.position;
            else lastGarbagePosition = _collectedGarbage.Peek().transform.position;

            var garbageScale = garbage.transform.lossyScale;
            var spawnPositionY = garbageScale.y + _indentBetweenGarbagesVertical;
            spawnPositionY = _collectedGarbage.Count % 2 == 1 ? 0 :  spawnPositionY;
            var spawnPositionX = _collectedGarbage.Count % 2 == 1 ? _indentBetweenGarbagesHorisontal : -_indentBetweenGarbagesHorisontal;

            var newPosition = new Vector3(
                lastGarbagePosition.x + spawnPositionX,
                lastGarbagePosition.y + spawnPositionY,
                lastGarbagePosition.z 
                );

            var garbageTransform = garbage.transform;
            garbageTransform.position = newPosition;
            garbageTransform.parent = _warehousePosition;
           // garbageTransform.localPosition = new Vector3(0, garbageTransform.localPosition.y, garbageTransform.localPosition.z);

        }
        [ContextMenu("Remove")]
        public void RemoveGarbage()
        {
            CurrentPoints -= _pointsToSpawnPressedGarbage;
            if (_collectedGarbage.Count <= 0) return;
            var lastCollectedGarbage = _collectedGarbage.Peek();
            lastCollectedGarbage.SetPickUpedState(false);
            _collectedGarbage.Pop();
        }
    }
}
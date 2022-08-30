using System;
using System.Collections.Generic;
using UnityEngine;

namespace Junky.Garbage
{
    public class GarbageCollector : MonoBehaviour
    {
        [SerializeField] private int _maxCollectedGarbage;
        [SerializeField] private Transform _collectorPosition;

        private Stack<PressedGarbage> _collectedGarbage = new Stack<PressedGarbage>();
        private int _currentPoints;
        public int CurrentPoints
        {
            get => _currentPoints;
            set
            {
                _currentPoints = value;
                var lastGarbage = _collectedGarbage.Peek();
                OnPointsChange.Invoke(value, lastGarbage.transform);
            }
        }
        public Action<int, Transform> OnPointsChange;
        public void TakeGarbage(PressedGarbage garbage)
        {
            if (_collectedGarbage.Count >= _maxCollectedGarbage ) return;


            PlaceGarbage(garbage);
            _collectedGarbage.Push(garbage);
            CurrentPoints += garbage.Points;
        }
        private void PlaceGarbage(PressedGarbage garbage)
        {
            var garbageScale = garbage.transform.lossyScale;
            Vector3 lastGarbagePosition;
            if (_collectedGarbage.Count <= 0) lastGarbagePosition = _collectorPosition.position;
            else lastGarbagePosition = _collectedGarbage.Peek().transform.position;


            var spawnPositionY = lastGarbagePosition.y + garbageScale.y;

            var newPosition = new Vector3(
                lastGarbagePosition.x,
                spawnPositionY,
                lastGarbagePosition.z
                );

            var garbageTransform = garbage.transform;
            garbageTransform.position = newPosition;
            garbageTransform.parent = _collectorPosition;
            garbageTransform.localPosition = new Vector3(0, garbageTransform.localPosition.y, garbageTransform.localPosition.z);
            garbage.SetPickUpedState(true);

        }
        [ContextMenu("Remove")]
        public void RemoveGarbage()
        {
            var lastCollectedGarbage = _collectedGarbage.Peek();
            _collectedGarbage.Pop();
            
            CurrentPoints -= lastCollectedGarbage.Points;
        }
    }
}
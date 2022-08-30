using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Junky.Garbage
{
    public class GarbagePickUper : MonoBehaviour
    {
        [SerializeField] private GarbageCollector _garbageCollector;
        public void TryPickUp(GameObject potentialGarbage)
        {
            var garbage = potentialGarbage.GetComponent<PressedGarbage>();
            if (garbage == null) return;

            _garbageCollector.TakeGarbage(garbage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junky.Garbage
{
    public class GarbageCollector : MonoBehaviour
    {
        [SerializeField] private float _removeGarbageCooldownTime;
        public void TryStartCollect(GameObject potentialGarbageWarehouse)
        {
            var garbageWarehouse = potentialGarbageWarehouse.GetComponent<GarbageWarehouse>();
            if (garbageWarehouse == null) return;

            StartCoroutine(Collect(garbageWarehouse));
        }
        public void StopCollect()
        {
            StopAllCoroutines();
        }
        private IEnumerator Collect(GarbageWarehouse garbageWarehouse)
        {
            while(garbageWarehouse.CurrentPoints>0)
            {
                garbageWarehouse.RemoveGarbage();
                yield return new WaitForSeconds(_removeGarbageCooldownTime);
            }

        }
    }
}
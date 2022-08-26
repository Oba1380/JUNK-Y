using UnityEngine;
using UnityEngine.Events;
using Junky.Utils;

namespace Junky.Eventers
{
    public class TriggerEnterEventer : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        [SerializeField] private UnityEvent<GameObject> _onTriggerEnter;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer))
            {
                _onTriggerEnter.Invoke(other.gameObject);
            }
        }
    }
}

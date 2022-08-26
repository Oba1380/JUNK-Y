using UnityEngine;
using UnityEngine.Events;
using Junky.Utils;

namespace Junky.Eventers
{
    public class ExitTriggerEventer : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        [SerializeField] private UnityEvent<GameObject> _onTriggerExit;
        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other.gameObject);
            if (other.gameObject.IsInLayer(_layer))
            {
                _onTriggerExit.Invoke(other.gameObject);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Events;
using Junky.Utils;

namespace Junky.Eventers
{
    public class CollisionEnterEventer : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        [SerializeField] private UnityEvent<GameObject> _onCollisionEnter;
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.IsInLayer(_layer))
            {
                _onCollisionEnter.Invoke(collision.gameObject);
            }
        }
    }
}

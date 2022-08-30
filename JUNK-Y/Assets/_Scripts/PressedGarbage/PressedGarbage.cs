using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junky.Garbage
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(DOScaleAnimatior))]
    public class PressedGarbage : MonoBehaviour
    {
        [SerializeField] private int _points;
        [SerializeField] private Quaternion _quaternionOnPickUp;
        public int Points => _points;

        private DOScaleAnimatior _myAnimator;
        private Rigidbody _myRigidbody;
        private Collider _myCollider;
        private void Awake()
        {
            _myCollider = GetComponent<Collider>();
            _myRigidbody = GetComponent<Rigidbody>();
            _myAnimator = GetComponent<DOScaleAnimatior>();
        }

        public void SetPickUpedState(bool state)
        {
            _myCollider.enabled = !state;
            _myRigidbody.isKinematic = state;
            if(state == true)
            {
                transform.localRotation = _quaternionOnPickUp;
                _myAnimator.Show();
            }
            else
            {
                _myAnimator.Hide();
            }
        }
    }
}


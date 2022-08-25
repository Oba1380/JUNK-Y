using UnityEngine;

namespace Junky
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _startSpeed;
        [SerializeField] private bool _randomise;
        private Rigidbody _rigidbody;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            if (_randomise) _startSpeed += Random.Range(-1, 1);
        }
        private void Start()
        {
            _rigidbody.AddRelativeForce(new Vector3(_startSpeed, 0, 0), ForceMode.Impulse);
        }
    }
}
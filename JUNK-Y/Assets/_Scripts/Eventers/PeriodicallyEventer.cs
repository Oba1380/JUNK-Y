using System.Collections;
using UnityEngine.Events;
using UnityEngine;

namespace Junky.Eventers
{
    public class PeriodicallyEventer : MonoBehaviour
    {
        [SerializeField] private UnityEvent _event;
        [SerializeField] private float _periodTime;
        private bool _isStarted;

        public void StartEvent()
        {
            if (_isStarted) return;

            StartCoroutine(DoEvent());
        }
        private IEnumerator DoEvent()
        {
            _isStarted = true;
            while (_isStarted)
            {
                _event?.Invoke();
                yield return new WaitForSeconds(_periodTime);
            }
        }
        public void StopEvent()
        {
            StopAllCoroutines();
            _isStarted = false;
        }
    }
}
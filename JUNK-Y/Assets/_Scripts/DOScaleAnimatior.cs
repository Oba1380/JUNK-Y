using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
namespace Junky
{
    public class DOScaleAnimatior : MonoBehaviour
    {
        [SerializeField] private float _firstStageTime;
        [SerializeField] private float _secondStageTime;

        [SerializeField] private float _scale;
        [SerializeField] private float _bounciness;

        [SerializeField] private bool _playOnStart;

        [SerializeField] private UnityEvent _onHide;
        private void Start()
        {
            if (_playOnStart)
            {
                Show();
            }
        }

        [ContextMenu("Show")]
        public void Show()
        {
            if (gameObject == null) return;
            transform.localScale = Vector3.zero;
            ScaleAnimate(_scale + _bounciness, _scale, _firstStageTime, _secondStageTime);
        }
        [ContextMenu("Hide")]
        public void Hide()
        {
            if (gameObject == null) return;
            ScaleAnimate(_scale + _bounciness, -0.2f, _secondStageTime, _firstStageTime);
        }
        private void ScaleAnimate(float firstScale, float secondScale, float firstStageTime, float secondStageTime)
        {
            var sequence = DOTween.Sequence();
            sequence.
                Append(transform.DOScale(firstScale, firstStageTime)).
                Append(transform.DOScale(secondScale, secondStageTime)).
                OnComplete(() => _onHide?.Invoke());
        }
    }
}

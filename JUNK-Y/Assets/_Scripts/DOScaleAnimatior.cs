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
            ScaleAnimate(_scale + _bounciness, _scale, _firstStageTime, _secondStageTime,false);
        }
        public void Show(Vector3 scale)
        {
            if (gameObject == null) return;
            transform.localScale = Vector3.zero;
            ScaleAnimate(scale, scale *(1+_bounciness), _firstStageTime, _secondStageTime, false);
        }
        [ContextMenu("Hide")]
        public void Hide()
        {
            if (gameObject == null) return;
            ScaleAnimate(_scale + _bounciness, 0, _secondStageTime, _firstStageTime,true);
        }
        private void ScaleAnimate(float firstScale, float secondScale, float firstStageTime, float secondStageTime, bool isHide)
        {
            var sequence = DOTween.Sequence();
            sequence.
                Append(transform.DOScale(firstScale, firstStageTime)).
                Append(transform.DOScale(secondScale, secondStageTime)).
                OnComplete(() => InvokeRightEvent(isHide));
        }
        private void ScaleAnimate(Vector3 firstScale, Vector3 secondScale, float firstStageTime, float secondStageTime, bool isHide)
        {
            var sequence = DOTween.Sequence();
            sequence.
                Append(transform.DOScale(firstScale, firstStageTime)).
                Append(transform.DOScale(secondScale, secondStageTime)).
                OnComplete(() => InvokeRightEvent(isHide));
        }
        private void InvokeRightEvent(bool isHide)
        {
            if (isHide) _onHide?.Invoke();
        }
    }
}

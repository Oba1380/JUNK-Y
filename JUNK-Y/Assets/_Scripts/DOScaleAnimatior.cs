using DG.Tweening;
using UnityEngine;

namespace Junky
{
    public class DOScaleAnimatior : MonoBehaviour
    {
        [SerializeField] private float _firstStageTime;
        [SerializeField] private float _secondStageTime;

        [SerializeField] private float _scale;
        [SerializeField] private float _bounciness;

        [SerializeField] private bool _playOnStart;
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
            transform.localScale = Vector3.zero;
            ScaleAnimate(_scale + _bounciness, _scale, _firstStageTime, _secondStageTime);
        }
        [ContextMenu("Hide")]
        public void Hide()
        {
            ScaleAnimate(_scale + _bounciness, 0, _secondStageTime, _firstStageTime);
        }
        private void ScaleAnimate(float firstScale, float secondScale, float firstStageTime, float secondStageTime)
        {
            var sequence = DOTween.Sequence();
            sequence.
                Append(transform.DOScale(firstScale, firstStageTime)).
                Append(transform.DOScale(secondScale, secondStageTime));
        }
    }
}

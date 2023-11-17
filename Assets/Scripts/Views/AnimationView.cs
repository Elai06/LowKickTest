using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class AnimationView : View
    {
        [SerializeField] private Animator _animationClip;
        [SerializeField] private Slider _slider;
        [SerializeField] private GameObject _circle;

        private Tween _tween;

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(SliderValueChanged);
            SliderValueChanged(_slider.value);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(SliderValueChanged);
            _tween?.Kill();
        }

        private void SliderValueChanged(float value)
        {
            //  _animationClip.speed = value;
            PlayAnimation(value);
        }

        private void PlayAnimation(float speed)
        {
            _tween = DOVirtual.Float(0, 280, speed, value =>
                {
                    _circle.transform.localPosition = Vector3.right * value;
                }).SetSpeedBased(true).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
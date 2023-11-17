using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class AnimationView : View
    {
        [SerializeField] private Animator _animationClip;
        [SerializeField] private Slider _slider;

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(SliderValueChanged);
            SliderValueChanged(_slider.value);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(SliderValueChanged);
        }

        private void SliderValueChanged(float value)
        {
             _animationClip.speed = value;
        }
    }
}
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScrollList : MonoBehaviour
    {
        public event Action<WidgetElement> UpdateUpperElement;
        public event Action<WidgetElement> UpdateLowerElement;

        [SerializeField] private ScrollRect _scrollRect;

        private float _scrollHeight;
        private float _widgetElementHeight;

        private int _maxElements;

        private Widget _widget;

        public void Initialize(Widget widget, int elementHeight, int maxElements)
        {
            _widget = widget;
            _widgetElementHeight = elementHeight;
            _scrollHeight = _widget.WidgetElements.Count * _widgetElementHeight;
            _maxElements = maxElements;
        }

        private void Update()
        {
            UpdateElementsPosition();
        }

        private void UpdateElementsPosition()
        {
            var widgetRect = transform as RectTransform;
            if (widgetRect == null) return;

            for (int i = 0; i < transform.childCount; i++)
            {
                var sctrollElement = _widget.WidgetElements[i];
                if (sctrollElement.transform.position.y < -_scrollHeight + widgetRect.rect.height)
                {
                    if (sctrollElement.GetIndex() - _widget.WidgetElements.Count < 0)
                    {
                        DOVirtual.Float(widgetRect.anchoredPosition.y, 0, 0.5f,
                            value => widgetRect.anchoredPosition = new Vector2(0, value));
                        _scrollRect.StopMovement();
                        return;
                    }

                    sctrollElement.transform.localPosition += new Vector3(0, _scrollHeight);
                    UpdateUpperElement?.Invoke(sctrollElement);
                }
                else if (sctrollElement.transform.position.y > widgetRect.rect.height + _widgetElementHeight)
                {
                    if (sctrollElement.GetIndex() + _widget.WidgetElements.Count >= _maxElements)
                    {
                        if (widgetRect.anchoredPosition.y >
                            _widgetElementHeight * _maxElements - _scrollHeight)
                        {
                            widgetRect.anchoredPosition = new Vector2(0, widgetRect.anchoredPosition.y - 1);
                            _scrollRect.StopMovement();
                        }

                        return;
                    }

                    sctrollElement.transform.localPosition -= new Vector3(0, _scrollHeight);
                    UpdateLowerElement?.Invoke(sctrollElement);
                }
            }
        }
    }
}
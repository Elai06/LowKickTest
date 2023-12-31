﻿using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class Widget : MonoBehaviour
    {
        [SerializeField] private WidgetElement _widgetElement;

        private Dictionary<int, WidgetElement> _widgetElements = new();
        [SerializeField] private int _spacing = 10;

        public Dictionary<int, WidgetElement> WidgetElements => _widgetElements;

        public void Initialize(List<WidgetElementData> widgetElementData, int count)
        {
            var heightWidgetElement = GetRectWidgetElement();
            for (int i = 0; i < count; i++)
            {
                var widget = Instantiate(_widgetElement, transform);
                widget.SetData(widgetElementData[i]);

                _widgetElements.Add(i, widget);
                SetWidgetPosition(widget, heightWidgetElement, i);
            }
        }

        private static void SetWidgetPosition(WidgetElement widget, float heightWidgetElement, int i)
        {
            widget.transform.localPosition = Vector3.down * heightWidgetElement * i;
        }

        public int GetRectWidgetElement()
        {
            var rectWidget = _widgetElement.transform as RectTransform;

            if (rectWidget != null)
                return (int)rectWidget.rect.height + _spacing;

            return 0;
        }
    }
}
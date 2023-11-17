using System;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class ScrollView : View
    {
        [SerializeField] private Widget _widget;
        [SerializeField] private int _widgetCounts = 10;
        [SerializeField] private int _widgetElementsDataCount = 1000;
        [SerializeField] private int _scrollingSpeed = 1;

        private int _startMousePos;

        private List<WidgetElementData> _widgetElementsData = new List<WidgetElementData>();

        private void Start()
        {
            CreateElementsData();

            _widget.Initialize(_widgetElementsData, _widgetCounts);
        }

        private void CreateElementsData()
        {
            for (int i = 0; i < _widgetElementsDataCount; i++)
            {
                _widgetElementsData.Add(new WidgetElementData
                {
                    Name = i.ToString(),
                    Index = i
                });
            }
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startMousePos = (int)Input.mousePosition.y;
            }

            if (Input.GetMouseButton(0))
            {
                if (_startMousePos != (int)Input.mousePosition.y)
                {
                    var delta = (int)Input.mousePosition.y - _startMousePos;
                    
                    if (delta > 0)
                    {
                        Scroll(_scrollingSpeed);
                    }
                    else
                    {
                        Scroll(-_scrollingSpeed);
                    }
                    
                    _startMousePos = (int)Input.mousePosition.y;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _startMousePos = 0;
            }
        }

        private void Scroll(int deltaMousePosition)
        {
            for (int i = 0; i < _widget.WidgetElements.Count; i++)
            {
                var widgetElement = _widget.WidgetElements[i];

                var updateIndex = deltaMousePosition + widgetElement.GetIndex();

                if (updateIndex < 0 || updateIndex >= _widgetElementsData.Count) return;

                widgetElement.UpdateData(_widgetElementsData[updateIndex]);
            }
        }
    }
}
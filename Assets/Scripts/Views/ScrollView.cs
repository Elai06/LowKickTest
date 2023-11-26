using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Views
{
    public class ScrollView : View
    {
        [SerializeField] private Widget _widget;
        [SerializeField] private ScrollList _scrollList;
        [SerializeField] private int _widgetCounts = 10;
        [SerializeField] private int _widgetElementsDataCount = 1000;

        private List<WidgetElementData> _widgetElementsData = new();

        private List<Sprite> _sprites = new();

        private void Start()
        {
            LoadSprites();

            CreateElementsData();
            _widget.Initialize(_widgetElementsData, _widgetCounts);
            _scrollList.Initialize(_widget, _widget.GetRectWidgetElement(), _widgetElementsDataCount);
        }

        private void LoadSprites()
        {
            for (int i = 0; i < _widgetCounts; i++)
            {
                _sprites.Add(GetRandomSprite());
            }
        }

        private void OnEnable()
        {
            _scrollList.UpdateLowerElement += OnUpdateLowerElement;
            _scrollList.UpdateUpperElement += OnUpdateUpperElement;
        }

        private void OnDisable()
        {
            _scrollList.UpdateLowerElement -= OnUpdateLowerElement;
            _scrollList.UpdateUpperElement -= OnUpdateUpperElement;
        }

        private void OnUpdateLowerElement(WidgetElement scrollElement)
        {
            var lastIndex = GetLastIndex();
            var data = _widgetElementsData[lastIndex + 1];
            scrollElement.SetData(data);
        }

        private void OnUpdateUpperElement(WidgetElement scrollElement)
        {
            var firstIndex = GetFirstIndex();
            var data = _widgetElementsData[firstIndex - 1];
            scrollElement.SetData(data);
        }

        private void CreateElementsData()
        {
            for (int i = 0; i < _widgetElementsDataCount; i++)
            {
                var sprite = _sprites[i % _sprites.Count];
                _widgetElementsData.Add(new WidgetElementData
                {
                    Name = i.ToString(),
                    Index = i,
                    Sprite = sprite
                });
            }
        }

        private Sprite GetRandomSprite()
        {
            var texture = ImageLoader.LoadImage();

            if (texture == null)
            {
                return null;
            }

            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        }

        private int GetLastIndex()
        {
            return _widget.WidgetElements.Values
                .Select(widgetWidgetElement => widgetWidgetElement.GetIndex())
                .Prepend(0).Max();
        }

        private int GetFirstIndex()
        {
            int index = _widget.WidgetElements[0].GetIndex();
            foreach (var widgetElement in _widget.WidgetElements.Values)
            {
                var widgetIndex = widgetElement.GetIndex();
                if (index > widgetIndex)
                {
                    index = widgetIndex;
                }
            }

            return index;
        }
    }
}
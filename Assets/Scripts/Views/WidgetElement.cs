using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class WidgetElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _image;

        private int _index;
        
        public void SetData(WidgetElementData data)
        {
            _text.text = $"{data.Name}";
            _index = data.Index;
            _image.sprite = data.Sprite;
        }

        public int GetIndex()
        {
            return _index;
        }
    }
}
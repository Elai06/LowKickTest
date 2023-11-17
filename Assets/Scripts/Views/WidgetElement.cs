using TMPro;
using UnityEngine;

namespace Views
{
    public class WidgetElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private int _index;
        
        public void SetData(WidgetElementData data)
        {
            _text.text = $"{gameObject.name + data.Name}";
            _index = data.Index;
        }

        public void UpdateData(WidgetElementData data)
        {
            SetData(data);
        }

        public int GetIndex()
        {
            return _index;
        }
    }
}
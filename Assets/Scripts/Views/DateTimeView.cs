using TMPro;
using UnityEngine;

namespace Views
{
    public class DateTimeView : View
    {
        [SerializeField] private TextMeshProUGUI _timeText;

        private void Start()
        {
            InvokeRepeating("UpdateTimeText", 0f, 1f);
        }

        private void UpdateTimeText()
        {
            _timeText.text = System.DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
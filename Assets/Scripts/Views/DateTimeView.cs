using System.Collections;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Views
{
    public class DateTimeView : View
    {
        [SerializeField] private TextMeshProUGUI _timeText;

        private readonly StringBuilder _stringBuilder = new();

        private void OnEnable()
        {
            StartCoroutine(SetDateTime());
        }

        private IEnumerator SetDateTime()
        {
            while (!IsActualDate())
            {
                UpdateDateTime();

                yield return new WaitForSeconds(1);
            }
        }

        private void UpdateDateTime()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendFormat(GetActualDateTime());
            _timeText.SetText(_stringBuilder.ToString());
        }

        private bool IsActualDate()
        {
            return _timeText.text == GetActualDateTime();
        }

        private string GetActualDateTime()
        {
            return System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
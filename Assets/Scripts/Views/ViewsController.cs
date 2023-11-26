using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class ViewsController : MonoBehaviour
    {
        [SerializeField] private List<View> _views;

        public void OpenView(EViewType eViewType)
        {
            for (int i = 0; i < _views.Count; i++)
            {
                var view = _views[i];

                view.gameObject.SetActive(view.ViewType == eViewType);
            }
        }
    }
}
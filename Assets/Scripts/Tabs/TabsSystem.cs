using UnityEngine;
using Views;

namespace Tabs
{
    public class TabsSystem : MonoBehaviour
    {
        [SerializeField] private Tab[] _tabButtons;
        [SerializeField] private ViewsController viewsController;
        
        private EViewType currentTab;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                _tabButtons[i].OnClick += ChangeTab;
            }
        }

        private void UnSubscribe()
        {
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                _tabButtons[i].OnClick -= ChangeTab;
            }
        }

        public void ChangeTab(EViewType eViewType)
        {
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                if (_tabButtons[i].ViewType == eViewType)
                {
                    viewsController.OpenView(eViewType);
                    _tabButtons[i].ChangeInteractable(false);
                }
                else
                {
                    _tabButtons[i].ChangeInteractable(true);
                }
            }
        }
    }
}
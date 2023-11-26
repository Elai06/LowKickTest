using System;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public event Action<EViewType> OnClick;

    [SerializeField] private EViewType _eViewType;

    private Button _button;

    public EViewType ViewType => _eViewType;

    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Click);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }

    private void Click()
    {
        OnClick?.Invoke(_eViewType);
    }

    public void ChangeInteractable(bool isInteractable)
    {
        _button.interactable = isInteractable;
    }
}
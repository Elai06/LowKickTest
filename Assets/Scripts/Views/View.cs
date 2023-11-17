using UnityEngine;

public abstract class View : MonoBehaviour
{
   [SerializeField] private EViewType _eViewType;

   public EViewType ViewType => _eViewType;
}
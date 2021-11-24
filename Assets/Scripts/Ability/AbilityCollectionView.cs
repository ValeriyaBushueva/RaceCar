using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{
    public event Action<IItem> UseRequested;
    
    private IReadOnlyList<IItem> _abilityItems;
        
    protected virtual void OnUseRequested(IItem e)
    {
        UseRequested?.Invoke(e);
    }

    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        _abilityItems = abilityItems;
    }
        
    public void Show()
    {
        // TODO показать объект
    }

    public void Hide()
    {
        // TODO скрыть объект
    }
}

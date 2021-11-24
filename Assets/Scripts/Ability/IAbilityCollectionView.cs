﻿using System;
using System.Collections.Generic;

public interface IAbilityCollectionView : IView
{
    event Action<IItem> UseRequested;
    void Display(IReadOnlyList<IItem> abilityItems);
}

using System.Collections.Generic;
using UnityEngine;

public class InventoryView : IInventoryView
{
    public void Display(IReadOnlyList<IItem> items)
    {
        foreach (var item in items)
        {
            Debug.Log($"Item Id{item.Id}, title:{item.ItemInfo.Title}");
        }
    }
}


using System.Collections.Generic;

public interface IInventoryModel
{
   IReadOnlyList<IItem> GetEquippedItem();
   void EquipItem(IItem item);
   void UnEquipItem(IItem item);
}

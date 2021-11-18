using System.Collections.Generic;
using Inventory.View;
using UnityEngine;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IInventoryView _inventoryView;
    private readonly IItemsRepository _itemsRepository;
    public InventoryController(List<ItemConfig> itemConfigs)
    {
        _inventoryModel = new InventoryModel();
        _itemsRepository = new ItemsRepository(itemConfigs);
        _inventoryView = Object.FindObjectOfType<InventoryViewComponent>();

    }
    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
        {
            _inventoryModel.EquipItem(item);
        }

        var equippedItems = _inventoryModel.GetEquippedItem();
        _inventoryView.Display(equippedItems);
    }
}

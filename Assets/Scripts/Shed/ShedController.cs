using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShedController :BaseController,IShedController
{
    private readonly IUpgradableCar _car;

    private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
    private readonly ItemsRepository _upgradeItemsRepository;
    private readonly InventoryModel _inventoryModel;
    private readonly IInventoryController _inventoryController;

    public ShedController(List<UpgradeItemConfig> upgradeItemConfigs, IUpgradableCar car)
    {
        _car = car;

        _upgradeHandlersRepository = new UpgradeHandlersRepository(upgradeItemConfigs);
        AddController(_upgradeHandlersRepository);

        _upgradeItemsRepository = new ItemsRepository(upgradeItemConfigs.Select(x => x.ItemConfig).ToList());
        AddController(_upgradeItemsRepository);
        
        _inventoryModel = new InventoryModel();
    }

    public void Enter()
    {
        Debug.Log($"Enter: car has speed : {_car.Speed}");
    }

    public void Exit()
    {
        UpgradeCarWithEquippedItems(_car, _inventoryModel.GetEquippedItem(), _upgradeHandlersRepository.UpgradeItems);
        Debug.Log($"Exit: car has speed : {_car.Speed}");
    }
    
    private void UpgradeCarWithEquippedItems(
        IUpgradableCar upgradableCar,
        IReadOnlyList<IItem> equippedItems,
        IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers)
    {
        foreach (var equippedItem in equippedItems)
        {
            if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                handler.Upgrade(upgradableCar);
        }
    }
}

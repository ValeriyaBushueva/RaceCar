public class AbilitiesController : BaseController, IAbilitiesController
{
    private readonly IRepository<int, IAbility> _abilityRepository;
    private readonly IInventoryModel _inventoryModel;
    private readonly IAbilityCollectionView _abilityCollectionView;
    
    public AbilitiesController(IRepository<int, IAbility> abilityRepository, InventoryModel inventoryModel,
        IAbilityCollectionView abilityCollectionView)
    {
        _abilityRepository = abilityRepository;
        _inventoryModel = inventoryModel;
        _abilityCollectionView = abilityCollectionView;
         
        SubscribeView(_abilityCollectionView);
    }

    protected override void OnDispose()
    {
        CleanupView(_abilityCollectionView);
        base.OnDispose();
    }
        
    private void SubscribeView(IAbilityCollectionView view)
    {
        view.UseRequested += OnAbilityUseRequested;
    }
      
    private void CleanupView(IAbilityCollectionView view)
    {
        view.UseRequested -= OnAbilityUseRequested;
    }

    private void OnAbilityUseRequested(IItem e)
    {
        if (_abilityRepository.Collection.TryGetValue(e.Id, out var ability))
            ability.Apply();
    }

    public void ShowAbilities()
    {
        _abilityCollectionView.Show();
        _abilityCollectionView.Display(_inventoryModel.GetEquippedItem());
    }
    
}

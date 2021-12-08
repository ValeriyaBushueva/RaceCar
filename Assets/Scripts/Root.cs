using System.Linq;
using Profile;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private UnityAdsTools _unityAdsTools;
    [SerializeField] private ItemConfig[] _itemsConfig; 
    [SerializeField] private  DailyRewardView _dailyRewardView; 
    [SerializeField] private  CurrencyView _currencyView;
    [SerializeField] private  FightWindowView _fightWindowView;
    [SerializeField] private  StartFightView _startFightView;
   
   private MainController _mainController;
   private void Awake()
    {
        var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer,_itemsConfig.ToList(), _dailyRewardView,
            _currencyView,_fightWindowView, _startFightView);
    }
   
   protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
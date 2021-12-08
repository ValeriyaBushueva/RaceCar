using  Profile;
using UnityEngine;
using Object = UnityEngine.Object;

public class FightWindowController :BaseController
{
    private FightWindowView _fightWindowView;
    private ProfilePlayer _profilePlayer;
    
    private Money _money;
    private Health _health;
    private Power _power;
    
    private Enemy _enemy;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    
    public FightWindowController(Transform placeForUi, ProfilePlayer profilePlayer, FightWindowView fightWindowView)
    {
        _profilePlayer = profilePlayer;
        _fightWindowView = Object.Instantiate(fightWindowView, placeForUi);
        AddGameObjects(_fightWindowView.gameObject );
    }

    public void RefreshView()
    {
        _enemy = new Enemy("Enemy");
        
        _money = new Money();
        _money.Attach(_enemy);
        
        _health = new Health();
        _health.Attach(_enemy);

        _power = new Power();
        _power.Attach(_enemy);

        SubscribeButtons();
    }

    private void SubscribeButtons()
    {
        _fightWindowView. AddCoinsButton.onClick.AddListener((() => ChangeMoney(true)));
        _fightWindowView.MinusCoinsButton.onClick.AddListener((() => ChangeMoney(false)));
      
        _fightWindowView.AddHealthButton.onClick.AddListener((() => ChangeHealth(true)));
        _fightWindowView.MinusHealthButton.onClick.AddListener((() => ChangeHealth(false)));
      
        _fightWindowView.AddPowerButton.onClick.AddListener((() => ChangePower(true)));
        _fightWindowView.MinusPowerButton.onClick.AddListener((() => ChangePower(false))); 
        _fightWindowView.FightButton.onClick.AddListener(Fight); 
        _fightWindowView.LeaveFightButton.onClick.AddListener(CloseWindow);
    }

    private void CloseWindow()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
    
    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer > _enemy.Power ? "Win" : "Lose");
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
        {
            _allCountMoneyPlayer++;
        }
        else
        {
            _allCountMoneyPlayer--;
        }

        ChangeDataWindow( _allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
        {
            _allCountHealthPlayer++;
        }
        else
        {
            _allCountHealthPlayer--;
        }

        ChangeDataWindow( _allCountMoneyPlayer, DataType.Health);
    }
    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
        {
            _allCountPowerPlayer++;
        }
        else
        {
            _allCountPowerPlayer--;
        }

        ChangeDataWindow( _allCountMoneyPlayer, DataType.Power);
    }
    
    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _fightWindowView.CountMoneyText.text = $"Player Money: {countChangeData}";
                _money.CountMoney = countChangeData;
                break;
            case DataType.Health:
                _fightWindowView.CountHealthText.text = $"PlayerHealth: {countChangeData}";
                _health.CountHealth = countChangeData;
                break;
            case DataType.Power:
                _fightWindowView.CountPowerText.text = $"Player Power: {countChangeData}";
                _power.CountPower = countChangeData;
                break;
        }
        
        _fightWindowView.CountPowerEnemyText.text = $"Player Enemy: {_enemy.Power}";
    }

    protected override void OnDispose()
    {
        _fightWindowView. AddCoinsButton.onClick.RemoveAllListeners();
        _fightWindowView.MinusCoinsButton.onClick.RemoveAllListeners();
      
        _fightWindowView.AddHealthButton.onClick.RemoveAllListeners();
        _fightWindowView.MinusHealthButton.onClick.RemoveAllListeners();
      
        _fightWindowView.AddPowerButton.onClick.RemoveAllListeners();
        _fightWindowView.MinusPowerButton.onClick.RemoveAllListeners();
        _fightWindowView.FightButton.onClick.RemoveAllListeners();
        _fightWindowView.LeaveFightButton.onClick.RemoveAllListeners();
        
        _money.Detach(_enemy);
        _health.Detach(_enemy);
        _power.Detach(_enemy);
        base.OnDispose();
    }
}

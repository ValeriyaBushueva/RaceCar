﻿using System.Collections.Generic;
using Profile;
using UnityEngine;

public class MainController : BaseController
{
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer,List<ItemConfig> itemsConfig, DailyRewardView dailyRewardView,
        CurrencyView currencyView,FightWindowView fightWindowView,  StartFightView startFightView)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        _itemsConfig = itemsConfig;
        _dailyRewardView = dailyRewardView;
        _currencyView = currencyView;
        _fightWindowView = fightWindowView;
        _startFightView = startFightView;
        
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private DailyRewardController _dailyRewardController;
    private StartFightController _startFightController;
    private FightWindowController _fightWindowController;
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private InventoryController _inventoryController;
    
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly List<ItemConfig> _itemsConfig;
    private readonly DailyRewardView _dailyRewardView; 
    private readonly CurrencyView _currencyView;
    private readonly FightWindowView _fightWindowView;
    private readonly StartFightView _startFightView;

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                
                _gameController?.Dispose();
                _dailyRewardController?.Dispose();
                break;
            
            case GameState.DailyReward:
                _dailyRewardController = new DailyRewardController(_placeForUi, _profilePlayer, _dailyRewardView, _currencyView);
                _dailyRewardController.RefreshView();
                
                _mainMenuController?.Dispose();
                break;
            
            case GameState.Fight:
                _fightWindowController = new FightWindowController(_placeForUi, _profilePlayer, _fightWindowView);
              _fightWindowController.RefreshView();
                
                _startFightController?.Dispose();
                _gameController?.Dispose();
                _mainMenuController?.Dispose();
                break;
            
            
            
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                _inventoryController = new InventoryController(_itemsConfig);
                
                _startFightController = new StartFightController(_placeForUi, _profilePlayer, _startFightView);
                _startFightController.RefreshView();
                _inventoryController.ShowInventory();
                
                _mainMenuController?.Dispose();
                _fightWindowController?.Dispose();
                break;
            
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _inventoryController?.Dispose();
                break;
        }
    }
}
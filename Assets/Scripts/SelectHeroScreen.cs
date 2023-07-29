using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SelectHeroScreen : MonoBehaviour
{
    private Action<int> _onHeroSelected;
    
    [SerializeField]
    private HeroStatsView _heroStatsView;

    [SerializeField]
    private Button _selectButton;
    [SerializeField]
    private Button _buyButton;
    
    private HeroLoader _heroLoader;
    private HeroesManager _heroesManager;
    private CurrencyManager _currencyManager;
    
    private int _currentHeroIndex;

    public void Initialize(HeroLoader heroLoader, HeroesManager heroesManager, CurrencyManager currencyManager,
        Action<int> onHeroSelected)
    {
        _heroLoader = heroLoader;
        _heroesManager = heroesManager;
        _currencyManager = currencyManager;
        _onHeroSelected = onHeroSelected;
    }
    
    public void ShowScreen(int currentHeroIndex)
    {
        ShowHero(currentHeroIndex);
    }

    [UsedImplicitly]
    public void BuyHero()
    {
        var currentHero = _heroesManager.GetCurrentHero(_currentHeroIndex);
        if (_currencyManager.BuyHero(currentHero.Price))
        {
            currentHero.ChangeAvailability(true);
            UpdateButtonsState(true);
            _heroesManager.SaveBoughtHeroes();
        }
    }

    [UsedImplicitly]
    public void SelectHero()
    {
        _onHeroSelected?.Invoke(_currentHeroIndex);
        PrefsManager.SaveSelectedHeroIndex(_currentHeroIndex);
    }
    
    [UsedImplicitly]
    public void SelectPreviousHero()
    {
        var newHeroIndex = _heroesManager.GetPreviousHeroIndex(_currentHeroIndex);
        ShowHero(newHeroIndex);
    }
    
    [UsedImplicitly]
    public void SelectNextHero()
    {
        var newHeroIndex = _heroesManager.GetNextHeroIndex(_currentHeroIndex);
        ShowHero(newHeroIndex);
    }

    private void ShowHero(int newHeroIndex)
    {
        _currentHeroIndex = newHeroIndex;
        var currentHero = _heroesManager.GetCurrentHero(_currentHeroIndex);
        _heroLoader.ShowHero(currentHero);
        _heroStatsView.ShowHeroStats(currentHero);
        UpdateButtonsState(currentHero.IsAvailable);
    }
    
    private void UpdateButtonsState(bool isSelected)
    {
        _selectButton.interactable = isSelected;
        _buyButton.gameObject.SetActive(!isSelected);
    }
}
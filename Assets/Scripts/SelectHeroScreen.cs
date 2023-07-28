using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SelectHeroScreen : MonoBehaviour
{
    private Action<int> _onHeroSelected;
    
    private HeroSettings[] _heroes => _heroesManager.Heroes;
    private HeroSettings _currentHero => _heroes[_currentHeroIndex];
    
    [SerializeField]
    private HeroStatsView _heroStatsView;

    [SerializeField]
    private Button _selectButton;
    [SerializeField]
    private Button _buyButton;
    
    private HeroLoader _heroLoader;
    private CurrencyManager _currencyManager;
    private HeroesManager _heroesManager;
    private int _currentHeroIndex;

    public void Initialize(HeroLoader heroLoader, CurrencyManager currencyManager,
        HeroesManager heroesManager, int currentHeroIndex, Action<int> onHeroSelected)
    {
        _heroLoader = heroLoader;
        _currencyManager = currencyManager;
        _heroesManager = heroesManager;
        _currentHeroIndex = currentHeroIndex;
        _onHeroSelected = onHeroSelected;
    }
    
    public void ShowScreen()
    {
        ShowHero(_currentHeroIndex);
    }

    [UsedImplicitly]
    public void BuyHero()
    {
        if (_currencyManager.BuyHero(_currentHero.Price))
        {
            _currentHero.ChangeAvailability(true);
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
    public void SelectNextHero()
    {
        _currentHeroIndex = (_currentHeroIndex + 1) % _heroes.Length;
        ShowHero(_currentHeroIndex);
    }
    
    [UsedImplicitly]
    public void SelectPreviousHero()
    {
        _currentHeroIndex = (_currentHeroIndex - 1 + _heroes.Length) % _heroes.Length;
        ShowHero(_currentHeroIndex);
    }

    private void ShowHero(int currentHeroIndex)
    {
        _currentHeroIndex = currentHeroIndex;
        _heroLoader.ShowHero(_currentHero);
        _heroStatsView.ShowHeroStats(_currentHero);
        UpdateButtonsState(_currentHero.IsAvailable);
    }
    
    private void UpdateButtonsState(bool isSelected)
    {
        _selectButton.interactable = isSelected;
        _buyButton.gameObject.SetActive(!isSelected);
    }
}
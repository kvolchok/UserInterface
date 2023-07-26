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

    private PrefsManager _prefsManager;
    private CurrencyManager _currencyManager;
    private HeroLoader _heroLoader;
    private HeroSettings[] _heroes;
    private int _currentHeroIndex;
    private HeroSettings _currentHero => _heroes[_currentHeroIndex];

    public void Initialize(PrefsManager prefsManager, CurrencyManager currencyManager, HeroLoader heroLoader,
        HeroSettings[] heroes, int currentHeroIndex, Action<int> onHeroSelected)
    {
        _prefsManager = prefsManager;
        _currencyManager = currencyManager;
        _heroLoader = heroLoader;
        _heroes = heroes;
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
            _currentHero.MarkAsAvailable();
            UpdateButtonsState(isSelected: true);
        }
        
        _prefsManager.SaveBoughtHero(_currentHeroIndex);
    }

    [UsedImplicitly]
    public void SelectHero()
    {
        _onHeroSelected?.Invoke(_currentHeroIndex);
        _prefsManager.SaveSelectedHeroIndex(_currentHeroIndex);
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
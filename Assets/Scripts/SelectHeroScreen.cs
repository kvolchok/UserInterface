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
    private HeroSettings[] _heroes;
    private int _currentHeroIndex;
    private HeroSettings _currentHero => _heroes[_currentHeroIndex];
    private Wallet _wallet;

    public void Initialize(HeroLoader heroLoader)
    {
        _heroLoader = heroLoader;
    }
    
    public void ShowScreen(HeroSettings[] heroes, int currentHeroIndex, Wallet wallet, Action<int> onHeroSelected)
    {
        _heroes = heroes;
        _wallet = wallet;
        _onHeroSelected = onHeroSelected;
        
        ShowHero(currentHeroIndex);
    }

    [UsedImplicitly]
    public void BuyHero()
    {
        if (_wallet.BuyHero(_currentHero.Price))
        {
            _currentHero.MarkAsAvailable();
            UpdateButtonsState(isSelected: true);
        }
    }

    [UsedImplicitly]
    public void SelectHero()
    {
        _onHeroSelected?.Invoke(_currentHeroIndex);
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
using JetBrains.Annotations;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameSettings _gameSettings;
    [SerializeField]
    private LobbyScreen _lobbyScreen;
    [SerializeField]
    private SelectHeroScreen _selectHeroScreen;
    [SerializeField]
    private CurrencyManager _currencyManager;
    
    [SerializeField]
    private HeroLoader _heroLoader;

    private PrefsManager _prefsManager;
    private int _currentHeroIndex;

    private void Awake()
    {
        _prefsManager = new PrefsManager();
        _prefsManager.UpdateBoughtHeroes(_gameSettings.Heroes);
        _currentHeroIndex = _prefsManager.GetSelectedHeroIndex();

        _currencyManager.Initialize(_prefsManager);
        _lobbyScreen.Initialize(_heroLoader);
        _selectHeroScreen.Initialize(_prefsManager, _currencyManager, _heroLoader,
            _gameSettings.Heroes, _currentHeroIndex, OnHeroSelected);
        
        ShowLobbyScreen();
    }

    [UsedImplicitly]
    public void ShowLobbyScreen()
    {
        _lobbyScreen.ShowScreen(_gameSettings.Heroes, _currentHeroIndex);
    }

    [UsedImplicitly]
    public void ShowSelectHeroScreen()
    {
        _selectHeroScreen.ShowScreen();
    }

    private void OnHeroSelected(int heroIndex)
    {
        _currentHeroIndex = heroIndex;
    }
}

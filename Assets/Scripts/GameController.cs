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
    private Wallet _wallet;
    
    [SerializeField]
    private HeroLoader _heroLoader;

    private int _currentHeroIndex;

    private void Awake()
    {
        _lobbyScreen.Initialize(_heroLoader);
        _selectHeroScreen.Initialize(_heroLoader);
        
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
        _selectHeroScreen.ShowScreen(_gameSettings.Heroes, _currentHeroIndex, _wallet, OnHeroSelected);
    }

    private void OnHeroSelected(int heroIndex)
    {
        _currentHeroIndex = heroIndex;
    }
}

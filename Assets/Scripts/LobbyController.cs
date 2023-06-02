using JetBrains.Annotations;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private GameSettings _gameSettings;
    [SerializeField]
    private LobbyScreen _lobbyScreen;
    [SerializeField]
    private SelectHeroScreen _selectHeroScreen;
    [SerializeField]
    private Wallet _wallet;

    private int _currentHeroIndex;

    private void Awake()
    {
        ShowLobbyScreen();
    }

    [UsedImplicitly]
    public void ShowLobbyScreen()
    {
        _lobbyScreen.ShowScreen(_currentHeroIndex, _gameSettings.Heroes);
    }

    [UsedImplicitly]
    public void ShowSelectHeroScreen()
    {
        _selectHeroScreen.ShowScreen(_currentHeroIndex, _gameSettings.Heroes, _wallet, OnHeroSelected);
    }

    private void OnHeroSelected(int heroIndex)
    {
        _currentHeroIndex = heroIndex;
    }
}

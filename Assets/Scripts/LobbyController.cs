using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private HeroesManager _heroesManager;
    [SerializeField]
    private LobbyScreen _lobbyScreen;
    [SerializeField]
    private SelectHeroScreen _selectHeroScreen;
    [SerializeField]
    private CurrencyManager _currencyManager;
    
    [SerializeField]
    private HeroLoader _heroLoader;
    
    private int _currentHeroIndex;

    private void Awake()
    {
        _heroesManager.UpdateBoughtHeroes();
        _currentHeroIndex = PrefsManager.GetSelectedHeroIndex();

        _currencyManager.SetStartCurrency();
        _lobbyScreen.Initialize(_heroLoader, _heroesManager);
        _selectHeroScreen.Initialize(_heroLoader, _heroesManager, _currencyManager, OnHeroSelected);
        
        ShowLobbyScreen();
    }

    [UsedImplicitly]
    public void ShowLobbyScreen()
    {
        _lobbyScreen.ShowScreen(_currentHeroIndex);
    }

    [UsedImplicitly]
    public void ShowSelectHeroScreen()
    {
        _selectHeroScreen.ShowScreen(_currentHeroIndex);
    }
    
    
    [UsedImplicitly]
    public void LoadBattleScene()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.BATTLE_SCENE);
    }

    private void OnHeroSelected(int heroIndex)
    {
        _currentHeroIndex = heroIndex;
    }
}
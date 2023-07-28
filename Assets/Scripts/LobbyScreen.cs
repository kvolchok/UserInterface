using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScreen : MonoBehaviour
{
    private const string BATTLE_SCENE = "BattleScene";
    
    [SerializeField]
    private HeroStatsView _heroStatsView;
    
    private HeroLoader _heroLoader;
    private HeroSettings _currentHero;

    public void Initialize(HeroLoader heroLoader)
    {
        _heroLoader = heroLoader;
    }
    
    public void ShowScreen(HeroSettings[] heroes, int heroIndex)
    {
        _currentHero = heroes[heroIndex];
        _heroStatsView.ShowHeroStats(_currentHero);
        _heroLoader.ShowHero(_currentHero);
    }

    [UsedImplicitly]
    public void LoadBattleScene()
    {
        DontDestroyOnLoad(_heroLoader);
        SceneManager.LoadSceneAsync(BATTLE_SCENE);
    }
}
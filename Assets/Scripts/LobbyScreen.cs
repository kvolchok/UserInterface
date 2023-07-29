using UnityEngine;

public class LobbyScreen : MonoBehaviour
{
    [SerializeField]
    private HeroStatsView _heroStatsView;
    
    private HeroLoader _heroLoader;
    private HeroesManager _heroesManager;

    public void Initialize(HeroLoader heroLoader, HeroesManager heroesManager)
    {
        _heroLoader = heroLoader;
        _heroesManager = heroesManager;
    }
    
    public void ShowScreen(int currentHeroIndex)
    {
        var currentHero = _heroesManager.GetCurrentHero(currentHeroIndex);
        _heroStatsView.ShowHeroStats(currentHero);
        _heroLoader.ShowHero(currentHero);
    }
}
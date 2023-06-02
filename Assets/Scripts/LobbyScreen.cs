using UnityEngine;

public class LobbyScreen : MonoBehaviour
{
    [SerializeField]
    private HeroStatsView _heroStatsView;
    [SerializeField]
    private HeroLoader _heroLoader;

    public void ShowScreen(int heroIndex, HeroSettings[] heroes)
    {
        var currentHero = heroes[heroIndex];
        _heroStatsView.ShowHeroStats(currentHero);
        _heroLoader.ShowHero(currentHero);
    }
}
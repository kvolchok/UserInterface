using UnityEngine;

public static class PrefsManager
{
    private const string BOUGHT_HEROES = "BoughtHeroes";
    private const string SELECTED_HERO = "SelectedHero";
    private const string MONEY = "Money";
    private const string GEMS = "Gems";

    public static void SaveBoughtHeroes(string boughtHeroes)
    {
        PlayerPrefs.SetString(BOUGHT_HEROES, boughtHeroes);
        PlayerPrefs.Save();
    }

    public static string GetBoughtHeroes()
    {
        return PlayerPrefs.HasKey(BOUGHT_HEROES) ? PlayerPrefs.GetString(BOUGHT_HEROES) : null;
    }

    public static void SaveSelectedHeroIndex(int heroIndex)
    {
        PlayerPrefs.SetInt(SELECTED_HERO, heroIndex);
        PlayerPrefs.Save();
    }

    public static int GetSelectedHeroIndex()
    {
        return PlayerPrefs.HasKey(SELECTED_HERO) ? PlayerPrefs.GetInt(SELECTED_HERO) : 0;
    }

    public static void SaveMoney(int money)
    {
        PlayerPrefs.SetInt(MONEY, money);
        PlayerPrefs.Save();
    }
    
    public static void SaveGems(int gems)
    {
        PlayerPrefs.SetInt(GEMS, gems);
        PlayerPrefs.Save();
    }

    public static int GetMoney()
    {
        return PlayerPrefs.HasKey(MONEY) ? PlayerPrefs.GetInt(MONEY) : -1;
    }
    
    public static int GetGems()
    {
        return PlayerPrefs.HasKey(GEMS) ? PlayerPrefs.GetInt(GEMS) : -1;
    }
}
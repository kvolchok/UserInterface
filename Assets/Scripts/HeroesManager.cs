using System;
using UnityEngine;

[Serializable]
public class HeroesManager : MonoBehaviour
{
    [SerializeField]
    private HeroSettings[] _heroes;
    [SerializeField]
    private int _defaultHeroIndex;

    private char[] _boughtHeroesArray;

    private void Awake()
    {
        DisableHeroesExceptDefault(_defaultHeroIndex);
        InitializeBoughtHeroesArray();
    }

    public HeroSettings GetCurrentHero(int currentHeroIndex)
    {
        return _heroes[currentHeroIndex];
    }
    
    public int GetPreviousHeroIndex(int currentHeroIndex)
    {
        return (currentHeroIndex - 1 + _heroes.Length) % _heroes.Length;
    }
    
    public int GetNextHeroIndex(int currentHeroIndex)
    {
        return (currentHeroIndex + 1) % _heroes.Length;
    }

    public void UpdateBoughtHeroes()
    {
        var boughtHeroes = PrefsManager.GetBoughtHeroes();

        if (string.IsNullOrEmpty(boughtHeroes))
        {
            return;
        }
        
        _boughtHeroesArray = boughtHeroes.ToCharArray();
        
        for (var i = 0; i < _heroes.Length; i++)
        {
            _heroes[i].ChangeAvailability(boughtHeroes[i] == '1');
        }
    }

    public void SaveBoughtHeroIndex(int heroIndex)
    {
        if (heroIndex >= 0 && heroIndex < _boughtHeroesArray.Length)
        {
            _boughtHeroesArray[heroIndex] = '1';
        }

        var boughtHeroes = string.Concat(_boughtHeroesArray);
        PrefsManager.SaveBoughtHeroes(boughtHeroes);
    }

    public void SaveSelectedHeroIndex(int heroIndex)
    {
        for (var i = 0; i < _heroes.Length; i++)
        {
            _heroes[i].ChangeLastSelectedState(i == heroIndex);
        }
        
        PrefsManager.SaveSelectedHeroIndex(heroIndex);
    }
    
    private void DisableHeroesExceptDefault(int defaultHeroIndex)
    {
        for (var i = 0; i < _heroes.Length; i++)
        {
            _heroes[i].ChangeAvailability(i == defaultHeroIndex);
        }
    }

    private void InitializeBoughtHeroesArray()
    {
        _boughtHeroesArray = new char[_heroes.Length];
        
        for (var i = 0; i < _heroes.Length; i++)
        {
            if (_heroes[i].IsAvailable)
            {
                _boughtHeroesArray[i] = '1';
            }
            else
            {
                _boughtHeroesArray[i] = '0';
            }
        }
    }
}
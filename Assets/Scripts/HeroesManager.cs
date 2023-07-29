using System;
using UnityEngine;

[Serializable]
public class HeroesManager : MonoBehaviour
{
    [SerializeField]
    private HeroSettings[] _heroes;

    private char[] _boughtHeroesArray;

    private void Awake()
    {
        _boughtHeroesArray = new char[_heroes.Length];
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
        for (var i = 1; i < _heroes.Length; i++)
        {
            _heroes[i].ChangeAvailability(false);
        }

        var boughtHeroes = PrefsManager.GetBoughtHeroes();

        if (string.IsNullOrEmpty(boughtHeroes))
        {
            return;
        }
        
        for (var i = 0; i < _heroes.Length; i++)
        {
            _heroes[i].ChangeAvailability(boughtHeroes[i] == '1');
        }
    }

    public void SaveBoughtHeroes()
    {
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

        var boughtHeroes = string.Concat(_boughtHeroesArray);
        PrefsManager.SaveBoughtHeroes(boughtHeroes);
    }
}
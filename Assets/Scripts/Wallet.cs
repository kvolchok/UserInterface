using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _lobbyScreenMoney;
    [SerializeField]
    private TextMeshProUGUI _selectHeroScreenMoney;
    
    [SerializeField]
    private int _currentMoney = 70000;

    private void Awake()
    {
        SetCurrentMoney();
    }

    public bool BuyHero(int price)
    {
        if (_currentMoney < price)
        {
            return false;
        }

        _currentMoney -= price;
        SetCurrentMoney();
        return true;
    }

    private void SetCurrentMoney()
    {
        _lobbyScreenMoney.text = _currentMoney.ToString();
        _selectHeroScreenMoney.text = _currentMoney.ToString();
    }
}
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _lobbyScreenMoney;
    [SerializeField]
    private TextMeshProUGUI _selectHeroScreenMoney;
    
    [SerializeField]
    private int _money;

    private void Awake()
    {
        SetCurrentMoney();
    }

    public bool BuyHero(int price)
    {
        if (_money < price)
        {
            return false;
        }

        _money -= price;
        SetCurrentMoney();
        return true;
    }

    private void SetCurrentMoney()
    {
        _lobbyScreenMoney.text = _money.ToString();
        _selectHeroScreenMoney.text = _money.ToString();
    }
}
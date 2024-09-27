using UnityEngine;
using UnityEngine.UI;

public class AutoClickerButtonManager : MonoBehaviour
{
    [SerializeField] private ClickerManager clickerManager;
    [SerializeField] private AutoClickerManager autoClickerManager1;
    [SerializeField] private AutoClickerManager autoClickerManager2;
    [SerializeField] private Button autoClickButton1;
    [SerializeField] private Button autoClickButton2;
    [SerializeField] private Text priceText1;
    [SerializeField] private Text priceText2;

    private int autoClicker1Price = 1000; 
    private int autoClicker2Price = 2000;  

    private void Start()
    {
        UpdatePriceTexts();
    }

    private void UpdatePriceTexts()
    {
        priceText1.text = "Цена: " + autoClicker1Price.ToString();
        priceText2.text = "Цена: " + autoClicker2Price.ToString();
    }

    public void BuyAutoClicker1()
    {
        if (clickerManager.GetCurrentMoney >= autoClicker1Price)
        {
           
            clickerManager.AddMoney(-autoClicker1Price);
            autoClickerManager1.StartAutoClick();
            autoClickButton1.interactable = false;
            UpdatePriceTexts();
        }
    }

    public void BuyAutoClicker2()
    {
        if (clickerManager.GetCurrentMoney >= autoClicker2Price)
        {
            clickerManager.AddMoney(-autoClicker2Price);
            autoClickerManager2.StartAutoClick();
            autoClickButton2.interactable = false;
            UpdatePriceTexts();
        }
    }
}
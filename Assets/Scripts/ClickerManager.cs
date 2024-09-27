using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private Button clickButton;
    [SerializeField] private Text textMoney;
    [SerializeField] private Text clickCountText;
    private int currentMoney;
    private int amountOfMoneyPerClick = 1;

    public int GetCurrentMoney => currentMoney;
    private void Start()
    {
        amountOfMoneyPerClick = PlayerPrefs.GetInt("Click", 1);
        currentMoney = PlayerPrefs.GetInt("Money", 0);
        clickButton.onClick.AddListener(Click);
        UpdateText();
    }

    private void UpdateText()
    {
        textMoney.text = currentMoney.ToString();
        clickCountText.text = amountOfMoneyPerClick.ToString();
    }
    private void Click()
    {
        AddMoney(amountOfMoneyPerClick);
    }

    public void AddClick(int bonusClick)
    {
        amountOfMoneyPerClick += bonusClick;
        PlayerPrefs.SetInt("Click", amountOfMoneyPerClick);
        UpdateText();
    }
    public void AddMoney(int count)
    {
        currentMoney += count;
        PlayerPrefs.SetInt("Money", currentMoney);
        UpdateText();
    }
    
}

using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private ClickerManager clickerManager; 
    [SerializeField] private Button bonusButton; 
    [SerializeField] private RectTransform bonusButtonRectTransform; 
    [SerializeField] private float minTimeToAppear = 30f; 
    [SerializeField] private float maxTimeToAppear = 120f; 
    [SerializeField] private float bonusDuration = 5f; 
    [SerializeField] private int minBonusAmount = 5000; 
    [SerializeField] private int maxBonusAmount = 200000; 
    [SerializeField] private Canvas canvas; 
    private int bonusAmount; 
    private float timeUntilNextBonus; 
    private bool bonusActive = false;

    private void Start()
    {
        bonusButton.gameObject.SetActive(false);
        bonusButtonRectTransform = bonusButton.GetComponent<RectTransform>();
        SetNextBonusTime();
    }

    private void Update()
    {
        if (bonusActive)
        {
            bonusDuration -= Time.deltaTime;
            if (bonusDuration <= 0)
            {
                HideBonus();
            }
        }
        else
        {
            timeUntilNextBonus -= Time.deltaTime;
            if (timeUntilNextBonus <= 0)
            {
                ShowBonus();
            }
        }
    }

    private void ShowBonus()
    {
        bonusActive = true;
        bonusButton.gameObject.SetActive(true); 
        SetRandomBonusPosition();
        bonusAmount = Random.Range(minBonusAmount, maxBonusAmount + 1); 
        Debug.Log("Получен бонус: " + bonusAmount); 

        bonusDuration = 5f; 
    }

    private void HideBonus()
    {
        bonusActive = false;
        bonusButton.gameObject.SetActive(false);
        SetNextBonusTime(); 
    }

    private void SetNextBonusTime()
    {
        timeUntilNextBonus = Random.Range(minTimeToAppear, maxTimeToAppear);
    }

    public void CollectBonus()
    {
        clickerManager.AddMoney(bonusAmount); 
        HideBonus(); 
    }

    private void SetRandomBonusPosition()
    {
        float canvasWidth = canvas.GetComponent<RectTransform>().rect.width;
        float canvasHeight = canvas.GetComponent<RectTransform>().rect.height;
        float randomX = Random.Range(0, canvasWidth - bonusButtonRectTransform.rect.width);
        float randomY = Random.Range(0, canvasHeight - bonusButtonRectTransform.rect.height);
        bonusButtonRectTransform.anchoredPosition = new Vector2(randomX, randomY);
    }
}

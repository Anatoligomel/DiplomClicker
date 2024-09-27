using System.Collections;
using UnityEngine;

public class AutoClickerManager : MonoBehaviour
{
    [SerializeField] private ClickerManager clickerManager; 
    [SerializeField] private int moneyPerClick = 1;
    [SerializeField] private float clickInterval = 1f; 
    private bool isAutoClicking = false; 

    public void StartAutoClick()
    {
        if (!isAutoClicking)
        {
            isAutoClicking = true;
            StartCoroutine(AutoClickRoutine());
        }
    }

    public void StopAutoClick()
    {
        isAutoClicking = false;
        StopCoroutine(AutoClickRoutine());
    }

    private IEnumerator AutoClickRoutine()
    {
        while (isAutoClicking)
        {
            clickerManager.AddMoney(moneyPerClick); 
            yield return new WaitForSeconds(clickInterval); 
        }
    }
}

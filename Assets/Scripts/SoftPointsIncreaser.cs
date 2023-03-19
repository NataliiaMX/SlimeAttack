using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoftPointsIncreaser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI softPointsText;
    [SerializeField] private Button attackhIncreaseButton;
    [SerializeField] private Button healthIncreaseButton;
    [SerializeField] private Button speedIncreaseButton;
    [SerializeField] private int softPoints = 0;

    private void Update() 
    {
        DisplaySoftCoins();
        CheckButtonsState();
    }

    private void CheckButtonsState()
    {
        if(softPoints < 10)
        {
            healthIncreaseButton.interactable = false;
        }
        else
        {
            healthIncreaseButton.interactable = true;
        }

        if(softPoints < 7)
        {
            attackhIncreaseButton.interactable = false;
        }
        else 
        {
            attackhIncreaseButton.interactable = true;
        }

        if(softPoints < 5)
        {
            speedIncreaseButton.interactable = false;
        }
        else
        {
            speedIncreaseButton.interactable = true;
        }
    }

    private void DisplaySoftCoins()
    {
        softPointsText.text = softPoints.ToString();
    }
    public void IncreaseSoftPoints(int value)
    {
        softPoints += value;
    }

    public void DecreaseSoftPoints(int value)
    {
        softPoints -= value;
    }

    public int GetSoftPoints()
    {
        return softPoints;
    }
}

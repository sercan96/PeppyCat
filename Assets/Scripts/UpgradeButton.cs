using System;
using JSLizards.Iguana.Scripts;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public int upgradeCost;
    public TextMeshProUGUI moneyText;
    public AnimalController animalCont;

    private void OnEnable()
    {
        upgradeCost = Convert.ToInt32(moneyText.text);
    }
}

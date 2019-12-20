using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public TextMeshProUGUI gemLabel;
    public Image weaponA;

    void Update()
    {
        gemLabel.text = SaveGameData.currentSave.inventory.gems.ToString("D3");  //3-decimal-number //000
        weaponA.gameObject.SetActive(SaveGameData.currentSave.inventory.weapon);
    }
}

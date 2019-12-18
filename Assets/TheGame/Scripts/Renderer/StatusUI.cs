using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUI : MonoBehaviour
{
    public TextMeshProUGUI gemLabel;


    void Update()
    {
        gemLabel.text = SaveGameData.currentSave.inventory.gems.ToString("D3");  //3-decimal-number //000
      
    }
}

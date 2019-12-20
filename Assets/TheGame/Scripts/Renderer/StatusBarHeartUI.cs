using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarHeartUI : MonoBehaviour
{
    public int value = 5;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();

    }

    void Update()
    {
        if (SaveGameData.currentSave.health.currentHealth >= value)
            image.color = Color.white;
        else
            image.color = Color.black;
    }
}

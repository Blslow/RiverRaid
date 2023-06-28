using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHealthHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text healthText;

    //public TMP_Text HealthText { get => healthText; }

    public void UpdateHealth(int value)
    {
        healthText.text = "HP: " + value.ToString();
    }
}

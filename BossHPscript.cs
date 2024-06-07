using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossHPscript : MonoBehaviour
{
    int BossHP;
    TMP_Text BossHPText;
    void Start()
    {
        BossHPText = GetComponent<TMP_Text>();
    }

    public void MinusBossHP(int HowMuchHPboss)
    {
        BossHP = HowMuchHPboss;
        BossHPText.text = $"Boss HP: {BossHP}";
    }
}

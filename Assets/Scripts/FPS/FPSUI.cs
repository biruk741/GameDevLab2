using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TMPro.TMP_Text enemyDefeatText;
    [SerializeField] private TMPro.TMP_Text ammoText;

    public void ShowHealthFraction(float fraction)
    {
        healthBar.fillAmount = fraction;
    }

    public void ShowEnemyDefeatCount(int count)
    {
        enemyDefeatText.text = "Enemies Defeated: " + count;
    }

    internal void showAmmo(int ammo)
    {
        ammoText.text = ammo.ToString();
    }
}

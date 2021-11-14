using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    public Text goldText, upgradeText;

    public Image weaponSprite;

    public void OnUpgradeClick()
    {
        if(GameManager.instance.TryUpgradeWeapon())
            UpgradeMenu();
    }
    public void UpgradeMenu()
    {

        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if(GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeText.text = "MAX";
        else
            upgradeText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();
        goldText.text = GameManager.instance.gold.ToString();
    }
}

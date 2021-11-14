using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Collectable
{
    public Sprite pickedUpHeal;
    public int healAmount = 1;

    protected override void OnCollect()
    {
        if(!collected)
        {
            collected=true;
            GetComponent<SpriteRenderer>().sprite = pickedUpHeal;
            GameManager.instance.player.Heal(healAmount);
            GameManager.instance.HitPointChange();
            GameManager.instance.ShowText("+" + healAmount + " HP", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        }
    }
}

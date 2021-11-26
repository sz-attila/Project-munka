using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC2 : Collectable
{   
    public string message = "Thank you for saving me!";
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GameManager.instance.ShowText(message, 30, Color.magenta, transform.position, Vector3.up * 100, 3f);
        }

    }
}

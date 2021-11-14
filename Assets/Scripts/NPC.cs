using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Collectable
{   
    public string message = "PLEASE save my sister! She is down there!";
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GameManager.instance.ShowText(message, 30, Color.green, transform.position, Vector3.up * 100, 3f);
        }

    }
}

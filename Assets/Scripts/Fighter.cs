using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    public int maxLife = 3;
    public int life;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImmune;
    protected Vector3 pushDirection;

    protected virtual void RecieveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            maxLife = life;
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            Debug.Log("Damage");
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);
            if(hitpoint <= 0)
            {
                    life--;
                    LifeChange();
                    hitpoint+=10;
                    transform.position = GameObject.Find("Position").transform.position;
                    if(life<=0)
                    {
                        Death();
                        life +=3;
                        
                    }
            }
            
        }
    }
    void LifeChange()
    {
        for (int i=0; i < hearts.Length; i++)
        {
            if(i < life)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    protected virtual void Death()
    {

    }
    
}

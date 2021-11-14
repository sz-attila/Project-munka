using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void RecieveDamage(Damage dmg)
    {
        base.RecieveDamage(dmg);
        GameManager.instance.HitPointChange();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x,y,0));
    }

    public void Heal(int healAmount)
    {
        if(hitpoint == maxHitpoint)
            return;
        hitpoint += healAmount;
        if(hitpoint>maxHitpoint)
            hitpoint=maxHitpoint;
    }
}

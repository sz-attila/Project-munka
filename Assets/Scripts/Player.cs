using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool Alive = true;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void RecieveDamage(Damage dmg)
    {
        if(!Alive)
            return;
        base.RecieveDamage(dmg);
        GameManager.instance.HitPointChange();
    }
    protected override void Death()
    {
        Alive = false;
        GameManager.instance.deathMenu.SetTrigger("Show");
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(Alive)
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
    public void Respawn()
    {
        Heal(maxHitpoint);
        Alive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}

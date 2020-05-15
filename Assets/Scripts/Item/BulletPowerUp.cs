using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : Item
{
    void Start(){

    }

    protected override void Update()
    {
        base.Update();
    }

    public override void OperateItem(){
        var player = GameObject.Find("Player");
        player.GetComponent<Shooter>()._powerUp = true;
    }
}

﻿using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Recharge")]
[Help("Go to base and refill ammo")]
public class Recharge : BasePrimitiveAction
{
    [InParam("Recharger")]
    GameObject recharger;

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        MyTankShoot shootComponent = recharger.GetComponent<MyTankShoot>();
        shootComponent.remainingBullets = shootComponent.maxBullets;
        return TaskStatus.COMPLETED;

    } // OnUpdate

} // class ShootOnce
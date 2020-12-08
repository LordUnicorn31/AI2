using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/HasAmmo")]
[Help("Checks if we have ammo to shoot")]
public class IsCopNear : ConditionBase
{
    [InParam("Checker")]
    GameObject checker;
    public override bool Check()
    {
        return (checker.GetComponent<MyTankShoot>().remainingBullets >= 0);
    }
}
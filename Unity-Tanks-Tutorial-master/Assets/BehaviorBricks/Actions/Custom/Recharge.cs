using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Recharge")]
[Help("Go to base and refill ammo")]
public class Recharge : BasePrimitiveAction
{
    [InParam("rechargeLocation")]
    Vector3 rechargeLocation;

    [InParam("Recharger")]
    GameObject recharger;

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        Movements moves = recharger.GetComponent<Movements>();
        moves.currentBehavior = Behaviors.none;
        moves.Seek(rechargeLocation);
        if (recharger.GetComponent<Transform>().position == rechargeLocation)
        {
            MyTankShoot shootComponent = recharger.GetComponent<MyTankShoot>();
            shootComponent.remainingBullets = shootComponent.maxBullets;
            return TaskStatus.COMPLETED;
        }
        return TaskStatus.RUNNING;

    } // OnUpdate

} // class ShootOnce
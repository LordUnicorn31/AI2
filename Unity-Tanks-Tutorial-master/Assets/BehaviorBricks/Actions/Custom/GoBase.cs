using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/GoBase")]
[Help("Go to base and refill ammo")]
public class GoBase : BasePrimitiveAction
{
    [InParam("base")]
    Vector3 rechargeLocation;

    [InParam("GameObject")]
    GameObject returner;

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        Movements moves = returner.GetComponent<Movements>();
        moves.currentBehavior = Behaviors.none;
        moves.Seek(rechargeLocation);
        return TaskStatus.COMPLETED;

    } // OnUpdate

} // class ShootOnce

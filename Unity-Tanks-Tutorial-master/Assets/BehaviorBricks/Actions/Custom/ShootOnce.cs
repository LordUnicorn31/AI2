using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/ShootOnce")]
[Help("Clone a 'bullet' and shoots it through the Forward axis with the " +
      "specified velocity.")]
public class ShootOnce : BasePrimitiveAction
{
    // Define the input parameter "shootPoint".
    [InParam("Shooter")]
    public GameObject shooter;

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        MyTankShoot Shooter = shooter.GetComponent<MyTankShoot>();
        Shooter.Fire();
        return TaskStatus.COMPLETED;

    } // OnUpdate

} // class ShootOnce
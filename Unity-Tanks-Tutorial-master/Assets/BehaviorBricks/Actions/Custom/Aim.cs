using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Aim")]
[Help("Aim at the target")]
public class Aim : BasePrimitiveAction
{
    // Define the input parameter "shootPoint".
    [InParam("Shooter")]
    public GameObject shooter;

    [InParam("target")]
    public GameObject target;

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        shooter.GetComponent<Transform>().LookAt(target.GetComponent<Transform>().position);
        return TaskStatus.COMPLETED;

    } // OnUpdate

} // class ShootOnce

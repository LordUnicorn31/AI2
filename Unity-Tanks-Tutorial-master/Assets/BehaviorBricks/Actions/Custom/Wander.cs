using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Wander")]
[Help("Set the behavior of the movement script to wander")]
public class Wander : BasePrimitiveAction
{
    [InParam("game object")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject targetGameobject;

    public override TaskStatus OnUpdate()
    {
        Movements moves = targetGameobject.GetComponent<Movements>();
        moves.freq = moves.updateTime;
        moves.currentBehavior = Behaviors.wander;
        return TaskStatus.COMPLETED;
    }
}
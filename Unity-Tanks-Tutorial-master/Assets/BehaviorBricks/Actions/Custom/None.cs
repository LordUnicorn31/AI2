using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/None")]
[Help("Perform no movement on the update method")]
public class None : BasePrimitiveAction
{
    [InParam("game object")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject targetGameobject;

    public override TaskStatus OnUpdate()
    {
        Movements moves = targetGameobject.GetComponent<Movements>();
        moves.freq = moves.updateTime;
        moves.currentBehavior = Behaviors.none;
        return TaskStatus.COMPLETED;
    }
}
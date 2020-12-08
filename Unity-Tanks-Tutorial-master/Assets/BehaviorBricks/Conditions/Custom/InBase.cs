using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/InBase")]
[Help("Checks if we are in base")]
public class InBase : ConditionBase
{
    [InParam("Checker")]
    GameObject checker;

    [InParam("baseLocation")]
    Vector3 basePosition;
    public override bool Check()
    {
        return Vector3.Distance(checker.GetComponent<Transform>().position, basePosition) < 5f;
    }
}

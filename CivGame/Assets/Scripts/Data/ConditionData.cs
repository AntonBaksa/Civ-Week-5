using UnityEngine;

public class ConditionData 
{
    public string conditionName = "Condition Name";
    public int amount = 1;

    public Compare compare = Compare.AtLeast;

    public bool IsMet(WorldState state) => Missing(state) == 0;

    public int Missing(WorldState state)
    {
        int v = state.Get(conditionName);
        if (compare == Compare.AtLeast) return Mathf.Max(0, amount - v);
        return Mathf.Max(0, v - amount);
    }
}

public enum Compare { AtLeast, AtMost}
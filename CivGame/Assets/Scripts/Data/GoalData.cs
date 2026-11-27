using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Civ/Goal")]
public class GoalData : ScriptableObject
{
    public List<ConditionData> wants = new List<ConditionData>();

    internal int Unmet(WorldState state)
    {
        return wants.Sum(w => w.Missing(state));
    }
}

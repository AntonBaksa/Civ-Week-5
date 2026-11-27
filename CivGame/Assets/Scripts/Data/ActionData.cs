using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(menuName = "Civ/Action")]
public class ActionData : ScriptableObject
{
    public string actionName = "Action Name";

    public List<ResourceQuantity> cost = new List<ResourceQuantity>();

    public List<ConditionData> requirements = new List<ConditionData>();
    public List<EffectData> effects = new List<EffectData>();

    public bool CanRun(WorldState state)
    {
        return requirements.All(c => c.IsMet(state));
    }

    public int Simulate(WorldState state)
    {
        return 1;
    }

    public Dictionary<string, int> Effects = new Dictionary<string, int>();

    public bool CanAfford(WorldState state)
    {
        return cost.All(c => state.Get(c.resource.displayName) >= c.Quantity);
    }

    public void Pay(WorldState s)
    {
        foreach ( var c in cost)
        {
            s[c.resource.displayName] = s.Get(c.resource.displayName) - c.Quantity;
        }
    }

    public void ApplyEffects(WorldState s)
    {
        foreach (var e in Effects)
        {
            //s[e.EffectName] = s.Get()
        }
    }

    public int TurnsToAfford(WorldState s)
    {
        // TODO: On a copy of s: return how many EndTurns until CanAfford (0 = now), -1 if more than 20
        return -1;
    }

}

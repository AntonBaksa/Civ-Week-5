using System;
using System.Collections.Generic;
using System.Linq;

public class WorldState : Dictionary<string, int>
{
    //WORLD STATE (as known to the AI)
    public WorldState() { }

    //Copy constructor. Used to simulate several outcomes.
    public WorldState(WorldState other) : base(other) { }

    public int Get(string key)
    {
        int v;
        return TryGetValue(key, out v) ? v : 0;
    }

    // One string per state, so the planner can tell if it has seen it before
    public string Key() { return string.Join(",", this.OrderBy(kv => kv.Key).Select(kv => kv.Key + "=" + kv.Value)); }

    //TODO: Implement EndTurn income and cleanup
    public void EndTurn()
    {
        foreach (var kv in Keys.ToList())
        {
            if (Key().EndsWith("Income"))
            {
                string stock = kv.Substring(0, kv.Length - "Income".Length);
                this[stock] = Math.Max(0, Get(stock) + this[kv]);
            }
        }
    }
}
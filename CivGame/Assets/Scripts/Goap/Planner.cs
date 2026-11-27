using System.Collections.Generic;
using UnityEngine;

public class Planner
{
    class Node
    {
        public WorldState State;
        public Node Parent;
        public ActionData Action;
        public int G, F;
    }

    public static List<ActionData> Plan(WorldState start, GoalData goal, List<ActionData> actions)
    {
        var open = new List<Node>
            {
                new Node {
                    State = start,
                    F = goal.Unmet(start)
                }
            };

        var closed = new HashSet<string>();

        // TODO: Set a max threshold of explored states
        while (open.Count > 0)
        {
            /*var node = open.OrderBy(n => n.F).First();
            open.Remove(node);

            //Is the goal met?
            if (goal.Unmet(node.State) == 0)
                return BuildPlan(node);

            //If the goal is not met, keep adding nodes

            //Skip already explored nodes
            if (!closed.Add(node.State.Key())) continue;

            foreach (var action in actions)
            {
                //Are the prerequirements met?
                if (!action.CanRun(node.State))
                    continue;

                var nextState = new WorldState(node.State);

                // TODO: turns = action.Simulate(nextState), skip the action if it returns -1
                int turns = 1;

                //Add next node to the open-list
                var next = new Node();
                next.State = nextState;
                next.Parent = node;
                next.Action = action;
                next.G = node.G + turns;
                next.F = next.G + goal.Unmet(next.State);
                open.Add(next);
            }*/
        }

        return null;
    }

    private static List<ActionData> BuildPlan(Node node)
    {
        var plan = new List<ActionData>();

        while (node.Parent != null)
        {
            plan.Insert(0, node.Action);
            node = node.Parent;
        }

        return plan;
    }
}

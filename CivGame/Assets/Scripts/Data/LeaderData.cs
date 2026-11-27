using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderData : MonoBehaviour
{
    public GoalData goal;
    public List<ActionData> actions = new List<ActionData>();
    public List<ResourceQuantity> startStock = new List<ResourceQuantity>();
    public List<EffectData> startState = new List<EffectData>();

    WorldState state = new WorldState();
    Queue<ActionData> plan = new Queue<ActionData>();
    int turn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(var r in startStock)
        {
            state[r.resource.displayName] = r.Quantity;
           
        }

        foreach(var e in startState)
        {
            //state[e.resource.effectName] = e.Amount;
        }
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        while(goal.Unmet(state)> 0)
        {
            OneMoreTurn();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Goal reached!");
    }

    private void OneMoreTurn()
    {
        turn++;

        if(plan.Count == 0 || !plan.Peek().CanRun(state) || plan.Peek().TurnsToAfford(state) < 0)
        {
            var steps = Planner.Plan(state, goal, actions);

            if(steps == null)
            {
                Debug.Log("no Plan");
                return;
            }

            plan = new Queue<ActionData>(steps);
            Debug.Log(steps.Select(a => a.actionName));
        }

        string did = "saving up";

        if(plan.Peek().CanAfford(state))
        {
            var next = plan.Dequeue();
            next.Pay(state);
            next.ApplyEffects(state);
            did = next.actionName;
        }

        Debug.Log(did);

        state.EndTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

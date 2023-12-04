using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectiveLib : MonoBehaviour
{
    static ChangeObjectiveLib instance;
    public void changeObjective(GameObject objectiveToRemove, GameObject objectiveToSet)
    {
        objectiveToRemove.SetActive(false);
        objectiveToSet.SetActive(true);
    }
    public void addObjective(GameObject objectiveToSet)
    {
        objectiveToSet.SetActive(true );
    }
    public void removeObjective(GameObject objectiveToRemove)
    {
        objectiveToRemove.SetActive(false);
    }
}

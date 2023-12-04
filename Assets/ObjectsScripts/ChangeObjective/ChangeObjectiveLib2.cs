using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectiveLib2 : MonoBehaviour
{
    public void changeObjective(GameObject objectiveToSet)
    {
        removeObjectives();
        objectiveToSet.SetActive(true);
    }
    public void addObjective(GameObject objectiveToSet)
    {
        objectiveToSet.SetActive(true);
    }
    public void removeObjectives()
    {
        GameObject gameObjectives = GameObject.Find("GameObjectives");

        
        if (gameObjectives != null)
        {
            
            foreach (Transform child in gameObjectives.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}

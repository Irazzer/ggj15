using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnTrigger : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        //TurnMazePart.Instance.TurnIt();
        int collNum = 0;
        int.TryParse(gameObject.name, out collNum);
        gameObject.SetActive(false);
        foreach (int i in getMovingParts(collNum))
        {
            TurnIt(Grid.Instance.MazeParts[i]);
            foreach (Transform child in Grid.Instance.MazeParts[i].transform)
            {
                if (child.name == i + "") { child.gameObject.SetActive(true); }
            }
        }
        
    }

    private void TurnIt(GameObject go)
    {
        // TODO: random rotation
        go.transform.Rotate(new Vector3(0, 90, 0)); 
    }


    private List<int> getMovingParts(int pos)
    {
        List<int> toTurn = new List<int>();
        int north = pos - 20;
        int south = pos + 20;
        int west = pos - 2;
        int east = pos + 2;

        int westL = west % 10;
        int eastL = east % 10;

        if (north >= 0) { toTurn.Add(north); }
        if (south <= 99) { toTurn.Add(south); }
        if (westL >= 0) { toTurn.Add(west); }
        if (eastL <= 9) { toTurn.Add(east); }

        return toTurn;
    }
}

using UnityEngine;
using System.Collections;

public class TurnMazePart : MonoBehaviour {


    private static TurnMazePart instance;
    public static TurnMazePart Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<TurnMazePart>();
            return instance;
        }
    }


    public void TurnIt()
    {
        gameObject.transform.Rotate(new Vector3(0, 90, 0));
    }



}

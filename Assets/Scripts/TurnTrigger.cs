using UnityEngine;
using System.Collections;

public class TurnTrigger : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        TurnMazePart.Instance.TurnIt();
    }
}

using UnityEngine;
using System.Collections;

public class FogTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = !RenderSettings.fog;
        gameObject.SetActive(false);
    }

 
}

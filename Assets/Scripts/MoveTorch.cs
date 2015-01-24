using UnityEngine;
using System.Collections;

public class MoveTorch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;


    public float minimumY = -60F;
    public float maximumY = 60F;

	// Update is called once per frame
	void Update () {
        float rotationY = 0f;
        Debug.Log(Input.GetAxis("Mouse Y"));
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.Rotate(new Vector3(-rotationY, 0, 0));
        //transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject FPC;
    public GameObject MainCamera;
    public GameObject PlayerSpawnPoint;
    public GameObject FogTrigger;

    private MouseLook mLook;
    private MouseLook mLookCam;

    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<GameController>();
            return instance;
        }
    }


	// Use this for initialization
	void Start () {
        mLook = FPC.GetComponent<MouseLook>();
        mLookCam = MainCamera.GetComponent<MouseLook>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void OnStartGame()
    {
        FPC.transform.position = PlayerSpawnPoint.transform.position;
        FPC.SetActive(true);
    }

    public void OnStartOver()
    {
        FogTrigger.SetActive(true);
        Grid.Instance.ResetGrid();
        FPC.transform.position = PlayerSpawnPoint.transform.position;
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            mLook.enabled = true;
            mLookCam.enabled = true;
        }
        else
        {
            Time.timeScale = 0f;
            mLook.enabled = false;
            mLookCam.enabled = false;
        }
    }
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject FPC;
    public GameObject MainCamera;
    public GameObject PlayerSpawnPoint;
    public GameObject FogTrigger;
    public GameObject DirectionalLight;
    public GameObject StartCamera;
    public GameObject HeartBeat;

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
        if (UIController.Instance.activeView == UIController.UIView.NoView && Input.GetKey(KeyCode.Escape))
        {
            UIController.Instance.CallUIMethod(UIController.UIView.InGame);
        }

        if (UIController.Instance.EndText.activeSelf && Input.GetKey(KeyCode.E))
        {
            UIController.Instance.CallUIMethod(UIController.UIView.End);
            UIController.Instance.EndText.SetActive(false);
        }
	}


    public void OnStartGame()
    {
        StartCamera.SetActive(false);
        FPC.transform.position = PlayerSpawnPoint.transform.position;
        FPC.SetActive(true);
    }

    public void OnStartOver()
    {
        resetGame();
    }

    public void OnEndGame()
    {
        resetGame();
        FPC.SetActive(false);
        StartCamera.SetActive(true);
    }

    private void resetGame()
    {
        FogTrigger.SetActive(true);
        DirectionalLight.SetActive(true);
        Grid.Instance.ResetGrid();
        FPC.transform.position = PlayerSpawnPoint.transform.position;
        FPC.transform.localRotation = Quaternion.identity;
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

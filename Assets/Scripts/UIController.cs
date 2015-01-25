using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

delegate void UIViewDelegate(bool activate);


public class UIController : MonoBehaviour
{
    // public gameobjects for unity
    public GameObject StartPanel;
    public GameObject HowToPanel;
    public GameObject InGamePanel;
    public GameObject CreditsPanel;
    public GameObject EndText;
    

    // public enum for controlling the views
    public enum UIView { Start = 0, HowTo = 1, InGame = 2, Credits = 3, NoView = 4 };
    public UIView activeView {get; set;}
    private UIView previousView;
   
    // dictionary for the method delegates
    private Dictionary<int, UIViewDelegate> methods;

    // instance of this class (singleton)
    private static UIController instance;
    public static UIController Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<UIController>();
            return instance;
        }
    }

    void Start()
    {
        methods = new Dictionary<int, UIViewDelegate>();
        registerUIViews();
    }

    private void registerUIViews()
    {
        Register(UIView.Start, HandleUIStart);
        Register(UIView.HowTo, HandleUIHowTo);
        Register(UIView.InGame, HandleUIInGame);
        Register(UIView.Credits, HandleUICredits);
        Register(UIView.NoView, HandleUINoView);
    }

    private void Register(UIView ui, UIViewDelegate processMessage)
    {
        int messageType = (int)ui;
        methods[messageType] = processMessage;
    }
    public void CallUIMethod(UIView newUI)
    {
        if (methods.ContainsKey((int)newUI))
        {
            if (activeView != newUI)
            {
                previousView = activeView;
                activeView = newUI;
                methods[(int)previousView](false);
                methods[(int)activeView](true);
            }
        }
    }

    /*
     * Delegate Classes
     */
    private void HandleUIStart(bool activate)
    {
        StartPanel.SetActive(activate);
    }
    private void HandleUIHowTo(bool activate)
    {
        HowToPanel.SetActive(activate);
    }
    private void HandleUIInGame(bool activate)
    {
        InGamePanel.SetActive(activate);
        GameController.Instance.TogglePause();
    }

    private void HandleUINoView(bool activate)
    {
        
    }

    private void HandleUICredits(bool activate)
    {
        CreditsPanel.SetActive(activate);
    }

    

    /*
     * Click Event Handler
     */
    public void BackToPrevious()
    {
        methods[(int)previousView](true);
        methods[(int)activeView](false);
        UIView buffer = activeView;
        activeView = previousView;
        previousView = buffer;
    }
    public void OnClickStart()
    {
        CallUIMethod(UIView.NoView);
        GameController.Instance.OnStartGame();
    }
    public void OnClickHowTo()
    {
        CallUIMethod(UIView.HowTo);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickCredits()
    {
        CallUIMethod(UIView.Credits);
    }

    public void ShowEndText()
    {
        EndText.SetActive(true);
    }

    public void OnClickStartOver()
    {
        BackToPrevious();
        GameController.Instance.OnStartOver();
    }

    public void OnClickEndGame()
    {
        CallUIMethod(UIView.Start);
        GameController.Instance.OnEndGame();
    }

    //// DEBUG ONLY
    public void DebugOnClickFog()
    {
        RenderSettings.fog = !RenderSettings.fog;
    }
    
   
  

}



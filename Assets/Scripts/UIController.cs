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

    // public enum for controlling the views
    public enum UIView { Start = 0, HowTo = 1, InGame = 2 };
    private UIView activeView;
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
    }
    public void OnClickHowTo()
    {
        CallUIMethod(UIController.UIView.HowTo);
    }
    public void OnClickExit()
    {
        
    }


    //// DEBUG
    public void DebugOnClickFog()
    {
        RenderSettings.fog = !RenderSettings.fog;
    }
   
  

}



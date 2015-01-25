using UnityEngine;
using System.Collections;
using ShinobiTools;

public class Heartbeat : ShinobiMono
{

    public void Awake()
    {
        SetTimer(60f, true, playHeartBeat);
	}
	
	public void playHeartBeat () {
        gameObject.audio.Play();
	}
}

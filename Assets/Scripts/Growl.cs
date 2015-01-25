using UnityEngine;
using System.Collections;
using ShinobiTools;

public class Growl : ShinobiMono
{

    public void Awake()
    {
        SetTimer(100f, true, playGrowl);
	}

    public void playGrowl()
    {
        gameObject.audio.Play();
	}
}

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
    // instance
    private static Grid instance;
    public static Grid Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Grid>();
            return instance;
        }
    }

    //public variables
    public GameObject MazePartI; // 15% probability
    public GameObject MazePartIK; // 5%
    public GameObject MazePartT; // 30% probability
    public GameObject MazePartTC; // 5%
    public GameObject MazePartL; // 22% probability
    public GameObject MazePartLS; // 8% probability
    public GameObject MazePartX; // 15% probability


    public GameObject spawnPoint;
    public GameObject Parent;
    public List<GameObject> MazeParts { get; set; }
    // private variables
    private List<int> grid;
    private Vector3 spPos;
    private float spYHalfScale;
    private int addX = 0;
    private int addZ = 0;
    private int row = 0;
    private int col = 0;
    private int partCount = 0;

	// Use this for initialization
	void Start () {
        grid = new List<int>();
        for(int i = 0; i < 100; i++)
        {
            if (i < 15) grid.Add(1);
            if (i >= 15 && i < 20) grid.Add(2);
            if (i >= 20 && i < 50) grid.Add(3);
            if (i >= 50 && i < 55) grid.Add(4);
            if (i >= 55 && i < 77) grid.Add(5);
            if (i >= 77 && i < 85) grid.Add(6);
            if (i >= 85) grid.Add(7);
        }
        MazeParts = new List<GameObject>();
        spPos = spawnPoint.transform.position;
        shuffle();
        instantiateGrid();
	}

    
    private void instantiateGrid()
    {
        System.Random rnd = new System.Random();
        int rotationY = 0;
        foreach (int mPart in grid)
        {
            int val = rnd.Next(1, 5);
            switch (val)
            {
                case 1: { rotationY = 0; break;}
                case 2: { rotationY = 90; break;}
                case 3: { rotationY = 180; break;}
                case 4: { rotationY = 270; break;}
            }

            switch (mPart)
            {
                case 1: { changeTriggerName(Instantiate(MazePartI, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.Euler(0, rotationY , 0)) as GameObject); break; }
                case 2: { changeTriggerName(Instantiate(MazePartIK, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.Euler(0, rotationY, 0)) as GameObject); break; }
                case 3: { changeTriggerName(Instantiate(MazePartT, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.Euler(0, rotationY, 0)) as GameObject); break; }
                case 4: { changeTriggerName(Instantiate(MazePartTC, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.Euler(0, rotationY, 0)) as GameObject); break; }
                case 5: { changeTriggerName(Instantiate(MazePartL, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.Euler(0, rotationY, 0)) as GameObject); break; }
                case 6: { changeTriggerName(Instantiate(MazePartLS, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.Euler(0, rotationY, 0)) as GameObject); break; }
                case 7: { changeTriggerName(Instantiate(MazePartX, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.Euler(0, rotationY, 0)) as GameObject); break; }
            }

            col++;
            if (col == 10) 
            { 
                row++;
                col = 0;
                addX = 0;
                addZ += 3;
            }
            else
            {
                addX += 3;
            }
            
        }
    }

    private void shuffle()
    {
        for (int i = 0; i < grid.Count; i++)
        {
            int temp = grid[i];
            int randomIndex = UnityEngine.Random.Range(0, grid.Count);
            grid[i] = grid[randomIndex];
            grid[randomIndex] = temp;
        }
    }

    private void changeTriggerName(GameObject go)
    {
        MazeParts.Add(go);
        go.transform.parent = Parent.transform;
        foreach (Transform child in go.transform)
        {
            child.name = partCount.ToString();
        }
        partCount++;
    }

    public void ResetGrid()
    {
        foreach (Transform child in Parent.transform)
        {
            Destroy(child.gameObject);
        }
        addX = 0;
        addZ = 0;
        row = 0;
        col = 0;
        partCount = 0;
        MazeParts = new List<GameObject>();
        RenderSettings.fog = false;
        shuffle();
        instantiateGrid();
    }
}

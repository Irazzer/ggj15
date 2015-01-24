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
    public GameObject MazePartI; // 20% probability
    public GameObject MazePartT; // 35% probability
    public GameObject MazePartL; // 30% probability
    public GameObject MazePartX; // 15% probability
    public GameObject spawnPoint;
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
            if (i < 20) grid.Add(1);
            if (i >= 20 && i < 55) grid.Add(2);
            if (i >= 55 && i < 85) grid.Add(3);
            if (i >= 85) grid.Add(4);
        }
        MazeParts = new List<GameObject>();
        spPos = spawnPoint.transform.position;
        shuffle();
        instantiateGrid();
	}

    
    private void instantiateGrid()
    {
        foreach (int mPart in grid)
        {
            switch (mPart)
            {
                case 1: { changeTriggerName(Instantiate(MazePartI, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity) as GameObject); break; }
                case 2: { changeTriggerName(Instantiate(MazePartT, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity) as GameObject); break; }
                case 3: { changeTriggerName(Instantiate(MazePartL, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity) as GameObject); break; }
                case 4: { changeTriggerName(Instantiate(MazePartX, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity) as GameObject); break; }
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
            int randomIndex = Random.Range(0, grid.Count);
            grid[i] = grid[randomIndex];
            grid[randomIndex] = temp;
        }
    }

    private void changeTriggerName(GameObject go)
    {
        MazeParts.Add(go);
        foreach (Transform child in go.transform)
        {
            child.name = partCount.ToString();
        }
        partCount++;
    }
}

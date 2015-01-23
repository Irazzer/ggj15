using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

    public GameObject MazePart01; // 30% probability
    public GameObject MazePart02; // 30% probability
    public GameObject MazePart03; // 30% probability
    public GameObject MazePart04; // 10% probability
    public GameObject spawnPoint;

    private List<int> grid;
    private Vector3 spPos;
    private float spYHalfScale;
    private int addX = 0;
    private int addZ = 0;

	// Use this for initialization
	void Start () {
        grid = new List<int>();
        for(int i = 0; i < 100; i++)
        {
            if (i < 30) grid.Add(1);
            if (i >= 30 && i < 60) grid.Add(2);
            if (i >= 60 && i < 90) grid.Add(3);
            if (i >= 90) grid.Add(4);
        }

        spPos = spawnPoint.transform.position;
        shuffle();
        instantiateGrid();
	}

    // Update is called once per frame
    void Update()
    {
	
	}

    private int row = 0;
    private int col = 0;
    private void instantiateGrid()
    {
        foreach (int mPart in grid)
        {
            switch (mPart)
            {
                case 1: { Instantiate(MazePart01, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity); break; }
                case 2: { Instantiate(MazePart02, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity); break; }
                case 3: { Instantiate(MazePart03, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity); break; }
                case 4: { Instantiate(MazePart04, new Vector3(spPos.x + addX, spPos.y + 1.5f, spPos.z + addZ), Quaternion.identity); break; }
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
}

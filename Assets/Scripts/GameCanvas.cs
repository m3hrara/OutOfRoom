using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField]
    private GameSlot gameSlot;
    [SerializeField]
    private GameSlot[,] gridArray;
    [SerializeField]
    private int gridSize = 3;
    public int randNum, pickedRow,PickedColumn, numOfGreens;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        numOfGreens = 4;
        Vector3 tempPos = transform.position;
        startPos = new Vector3(15, 17, 87);
        gridArray = new GameSlot[3, 3];
        for(int row =0;row<3;row++)
        {
            for (int column = 0; column < 3; column++)
            {
                gridArray[row, column] = Instantiate(gameSlot, tempPos, transform.rotation);
                gridArray[row, column].gameObject.transform.position = startPos;
                gridArray[row, column].row = row;
                gridArray[row, column].column = column;
                startPos.x += 6;
            }
            startPos.x = 15;
            startPos.y -= 6;
        }
        RandomizePattern();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RandomizePattern()
    {
        while (numOfGreens>0)
        {
            randNum = Random.Range(0, 3);
            pickedRow = randNum;
            randNum = Random.Range(0, 3);
            PickedColumn = randNum;
            if(!gridArray[pickedRow,PickedColumn].isGreen)
            {
                gridArray[pickedRow, PickedColumn].isGreen = true;
                numOfGreens--;

            }
        }
    }
}

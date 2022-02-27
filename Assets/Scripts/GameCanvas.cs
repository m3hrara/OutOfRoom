using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    public GameObject ball1, ball2, ball3, ball4;
    public GameObject ball5, ball6, ball7, ball8;
    public int checkmark = 0;
    public int numOfPlays = 2;
    [SerializeField]
    private GameSlot gameSlot;
    [SerializeField]
    private GameSlot[,] gridArray;
    [SerializeField]
    private GroundSlot groundSlot;
    [SerializeField]
    private GroundSlot[,] groundArray;
    [SerializeField]
    private int gridSize = 3;
    public int randNum, pickedRow,PickedColumn, numOfGreens;
    private Vector3 startPos, groundPos;
   public Quaternion quaternion;
    // Start is called before the first frame update
    void Start()
    {
        quaternion = new Quaternion();
        quaternion.Set(1f, 0, 0, 1);
        numOfGreens = 4;
        Vector3 tempPos = transform.position;
        startPos = new Vector3(15, 17, 87);
        groundPos = new Vector3(15f, -3.2f, 52f);
        gridArray = new GameSlot[3, 3];
        groundArray = new GroundSlot[3, 3];
        for (int row =0;row<3;row++)
        {
            for (int column = 0; column < 3; column++)
            {
                gridArray[row, column] = Instantiate(gameSlot, tempPos, transform.rotation);
                gridArray[row, column].gameObject.transform.position = startPos;
                gridArray[row, column].row = row;
                gridArray[row, column].column = column;
                startPos.x += 6;

                groundArray[row, column] = Instantiate(groundSlot,tempPos, quaternion);
                groundArray[row, column].gameObject.transform.position = groundPos;
                groundArray[row, column].row = row;
                groundArray[row, column].column = column;
                groundPos.x += 4;
            }
            startPos.x = 15;
            startPos.y -= 6;

            groundPos.x = 15f;
            groundPos.z -= 4;
        }
        RandomizePattern();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkmark==4)
        {
            numOfGreens = 4;
            ResetColor();
            RandomizePattern();
            ball1.gameObject.SetActive(false);
            ball2.gameObject.SetActive(false);
            ball3.gameObject.SetActive(false);
            ball4.gameObject.SetActive(false);
            ball5.gameObject.SetActive(true);
            ball6.gameObject.SetActive(true);
            ball7.gameObject.SetActive(true);
            ball8.gameObject.SetActive(true);

            checkmark = 0;
            numOfPlays--;
        }
        else if(numOfPlays==0)
        {
            // end game
        }
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
                groundArray[pickedRow, PickedColumn].isGreen = true;
                numOfGreens--;
            }
        }
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (gridArray[row, column].isGreen)
                    gridArray[row, column].SetGreen();
                else
                    gridArray[row, column].SetRed();
            }

        }

    }
    void ResetColor()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                gridArray[row, column].isGreen = false;
                groundArray[row, column].isGreen = false;
                gridArray[row, column].SetRed();
            }

        }
    }
}

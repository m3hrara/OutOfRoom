using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameCanvas gameCanvas;
    public GameObject leftWall,rightWall;
    public float leftPos,rightPos;
    // Start is called before the first frame update
    void Start()
    {
        gameCanvas = FindObjectOfType<GameCanvas>();
        leftPos = leftWall.transform.position.x;
        rightPos = rightWall.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        leftPos += 0.02f;
        leftWall.transform.position = new Vector3(leftPos, leftWall.transform.position.y, leftWall.transform.position.z);

        rightPos -= 0.02f;
        rightWall.transform.position = new Vector3(rightPos, rightWall.transform.position.y, rightWall.transform.position.z);
    }
    private void Update()
    {
        if(leftPos>=12.5 && rightPos<=22.5)
        {
            gameCanvas.numOfPlays = 0;
        }
    }
}

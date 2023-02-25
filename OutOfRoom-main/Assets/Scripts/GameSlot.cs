using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameSlot : MonoBehaviour
{
    private GameCanvas gameCanvas;
    public Material redMat, greenMat;
    public int row, column;
    public bool isGreen = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = redMat;
        gameCanvas = FindObjectOfType<GameCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGreen)
        {
            this.GetComponent<MeshRenderer>().material = greenMat;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = redMat;
        }
    }
    public void SetGreen()
    {
        this.GetComponent<MeshRenderer>().material = greenMat;
    }
    public void SetRed()
    {
        this.GetComponent<MeshRenderer>().material = redMat;
    }
}

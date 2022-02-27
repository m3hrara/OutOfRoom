using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlot : MonoBehaviour
{
    public GameCanvas gameCanvas;
    public int row, column;
    public bool isGreen = false;
    private void Start()
    {
        gameCanvas = FindObjectOfType<GameCanvas>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("moveable"))
        {
            if(isGreen)
            {
                gameCanvas.checkmark++;
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("moveable"))
        {
            if (isGreen)
            {
                if(gameCanvas.checkmark>0)
                gameCanvas.checkmark--;
            }
        }
    }
}

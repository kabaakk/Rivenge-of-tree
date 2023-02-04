using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    [SerializeField] private GameObject tileObject;

    [SerializeField] private float localScaleValue = 3f;
    [SerializeField] private float tileLength = 1f;


    private void Start()
    {
        GenerateArea(transform.position, 10, 10);
    }

    public void GenerateArea(Vector3 startPos, float xDistance, float yDistance)
    {
        
        Vector3 leftTopPos =startPos + Vector3.forward* yDistance + Vector3.left * xDistance;
        
        float tileCountX = xDistance*2 / tileLength;
        float tileCountY = yDistance*2 / tileLength;
        int multiplierVar = 1;
        bool isOdd = false;


        Vector3 rotation = Vector3.zero;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < tileCountX; j++)
            {
                GameObject tile = Instantiate(tileObject, transform.position, Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.transform.localPosition = leftTopPos;

                tile.transform.rotation = Quaternion.Euler(rotation);
                tile.transform.localScale = new Vector3(localScaleValue, localScaleValue, localScaleValue);
                leftTopPos += Vector3.right*tileLength   * multiplierVar;
            }
           
            rotation += Vector3.up * 90;
            // put y tiles
            for (int j = 0; j < tileCountY; j++)
            {
                GameObject tile = Instantiate(tileObject, transform.position, Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.transform.rotation = Quaternion.Euler(rotation);

                tile.transform.localScale = new Vector3(localScaleValue, localScaleValue, localScaleValue);
                tile.transform.localPosition = leftTopPos;

                leftTopPos += Vector3.back *tileLength  * multiplierVar;
            }
            
            rotation += Vector3.up * 90;

            multiplierVar = -1;
            isOdd = !isOdd;

        }
      
     
        
    }
}

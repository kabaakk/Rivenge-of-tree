using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    [SerializeField] private GameObject tileObject;

    [SerializeField] private float localScaleValue = 3f;
    [SerializeField] private float tileLength = 1f;


    private List<Transform> fences = new List<Transform>();
    
    private void Start()
    {
        //StartCoroutine(GenerateArea(transform.position, 10, 10));
        ActionManager.instance.ArenaSurvivalStarted += ArenaSurvivalStarted;
        ActionManager.instance.ArenaSurvived += ArenaSurvived;
    }

    private IEnumerator GenerateArea(Vector3 startPos, float xDistance, float yDistance)
    {
        transform.position = PlayerArenaEndShoot.instance.transform.position;

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
                fences.Add(tile.transform);
                tile.transform.rotation = Quaternion.Euler(rotation);
                tile.transform.localScale = Vector3.zero;
                tile.transform.DOScale(new Vector3(localScaleValue, localScaleValue, localScaleValue),0.5f);
                leftTopPos += Vector3.right*tileLength   * multiplierVar;
                yield return null;
            }
           
            rotation += Vector3.up * 90;
            // put y tiles
            for (int j = 0; j < tileCountY; j++)
            {
                GameObject tile = Instantiate(tileObject, transform.position, Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.transform.rotation = Quaternion.Euler(rotation);
                fences.Add(tile.transform);

                tile.transform.DOScale(new Vector3(localScaleValue, localScaleValue, localScaleValue),0.5f);
                tile.transform.localPosition = leftTopPos;

                leftTopPos += Vector3.back *tileLength  * multiplierVar;
                yield return null;

            }
            
            rotation += Vector3.up * 90;

            multiplierVar = -1;
            isOdd = !isOdd;

        }
      
     
        
    }

    private void ScaleAllFences()
    {

        StartCoroutine(ScaleUpCoroutine());
    }

    private IEnumerator ScaleUpCoroutine()
    {
        transform.position = PlayerArenaEndShoot.instance.transform.position;
        foreach (var fence in fences)
        {
            fence.DOScale(new Vector3(localScaleValue, localScaleValue, localScaleValue),0.5f);
            yield return null;
        }
        
        
        
    }
     

    private void ScaleAllFencesDown()
    {
        
        
        foreach (var fence in fences)
        {
            fence.DOScale(Vector3.zero,0.5f);
        }
    }
    
    private void ArenaSurvivalStarted()
    {
        if (fences.Count > 0)
        {
            ScaleAllFences();
        }
        else
        {
            StartCoroutine(GenerateArea(transform.position, 14, 9));

        }
    }

    private void ArenaSurvived()
    {
        ScaleAllFencesDown();
    }
}

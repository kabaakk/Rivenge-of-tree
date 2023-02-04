using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSmallController : MonoBehaviour
{
    [SerializeField] private List<GameObject> treeParts;
    
    public void GrowTree()
    {
       
        StartCoroutine(GrowTreeCoroutine());
    }
    
    private IEnumerator GrowTreeCoroutine()
    {
        foreach (var treePart in treeParts)
        {
            treePart.SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
        
    }
  
}

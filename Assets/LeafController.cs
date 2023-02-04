using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> leafs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AmmoCountChanged(int currentAmmo, int maxAmmo)
    {
        
        
        
        for (int i = 0; i < leafs.Count; i++)
        {
            if (i < currentAmmo)
            {
                leafs[i].SetActive(true);
            }
            else
            {
                leafs[i].SetActive(false);
            }
        }
        
        
        
    }
}

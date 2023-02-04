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
        if (currentAmmo == 0)
        {
            foreach (var leaf in leafs)
            {
                leaf.SetActive(false);
            }

            return;
        }

        float ammoPercent = (float)currentAmmo / (float)maxAmmo;


      
        int leafIndex = 0;
        if (ammoPercent > 0.8f)
        {
            leafIndex = 2;

        }
        
        else if (ammoPercent > 0.4f)
        {
            leafIndex = 1;
        }

        else
        {
            leafIndex = 0;
        }


        foreach (var leaf in leafs)
        {
            if (leafs.IndexOf(leaf) == leafIndex)
            {
                leaf.SetActive(true);
            }
            else
            {
                leaf.SetActive(false);
            }
            
        }
       
       
        
        
        
    }
}

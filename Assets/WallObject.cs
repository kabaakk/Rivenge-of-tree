using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : MonoBehaviour
{

    [SerializeField] private List<TreeSmallController> smallTrees;
    // Start is called before the first frame update

    public void GrowAllTrees()
    {
        Vector3 playerPos = PlayerArenaEndShoot.instance.transform.position;
        transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));
        StartCoroutine(GrowAllCoroutine());

    }

    private IEnumerator GrowAllCoroutine()
    {
        foreach (var smallTree in smallTrees)
        {
            smallTree.GrowTree();
            yield return new WaitForSeconds(0.1f);
        }
        
        
    }
}

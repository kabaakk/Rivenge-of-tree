using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WallObject : MonoBehaviour
{

    [SerializeField] private List<TreeSmallController> smallTrees;
    // Start is called before the first frame update
    [SerializeField] private GameObject pineCone;

    public void GrowAllTrees()
    {
        pineCone.SetActive(false);
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


        yield return new WaitForSeconds(1f);

        transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InSine).OnComplete(() =>

            Destroy(gameObject));
        ;

    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class TreePartController : MonoBehaviour
{
    [SerializeField] private List<GameObject> treeParts;
    [SerializeField] private ParticleSystem growParticle;
    
    public void GrowTree()
    {
        growParticle.Play();
        StartCoroutine(GrowTreeCoroutine());
    }
    
    private IEnumerator GrowTreeCoroutine()
    {
        foreach (var treePart in treeParts)
        {
            treePart.SetActive(true);
            treePart.transform.localScale = Vector3.zero;
            treePart.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.InSine);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.2f);
        GetComponentInParent<PlayerStateController>().FinishedGrowing();
    }

    public void CloseTree()
    {
        
        foreach (var treePart in treeParts)
        {
            treePart.SetActive(false);
        }
    }
}

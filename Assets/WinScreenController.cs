using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    [SerializeField] private RectTransform inGameOptionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        inGameOptionsPanel.localScale = Vector3.zero;
        inGameOptionsPanel.gameObject.SetActive(false);
        ActionManager.instance.GameWin += OpenPanel;
    }

    
    public void OpenPanel()
    {
        inGameOptionsPanel.gameObject.SetActive(true);
        inGameOptionsPanel.DOScale(Vector3.one, 0.3f).SetUpdate(true);
    }
}

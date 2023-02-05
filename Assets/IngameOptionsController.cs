using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IngameOptionsController : MonoBehaviour
{
    
    [SerializeField] private RectTransform ingameOptionsPanel;
    private bool isPanelOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        ingameOptionsPanel.localScale = Vector3.zero;
        ingameOptionsPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPanelOpen)
                ClosePanel();
            else
                OpenPanel();
            
        }
    }


    private void ClosePanel()
    {
        
        ingameOptionsPanel.DOScale(Vector3.zero, 0.3f).SetUpdate(true).OnComplete(()=>ClosingFunctions());

    }


    private void ClosingFunctions()
    {
        isPanelOpen = false;
        Time.timeScale = 1f;

        ingameOptionsPanel.gameObject.SetActive(false);

    }

    private void OpenPanel()
    {
        isPanelOpen = true;

        Time.timeScale = 0f;
        ingameOptionsPanel.gameObject.SetActive(true);
        ingameOptionsPanel.DOScale(Vector3.one, 0.3f).SetUpdate(true);
    }
}

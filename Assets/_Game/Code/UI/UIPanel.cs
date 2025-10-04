using System;
using DG.Tweening;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    private RectTransform _panelRectTransform;
    private float _animationDuration = 0.3f;
    private Ease showEase = Ease.OutBack;
    private Ease hideEase = Ease.InBack;
    
    private Vector3 originalScale;
    

    private void Awake()
    {
        _panelRectTransform = GetComponent<RectTransform>();
        originalScale = _panelRectTransform.localScale;
    }


    public void Show()
    {
        _panelRectTransform.DOKill();
        gameObject.SetActive(true);
        //_panelRectTransform.localScale = Vector3.zero;
        _panelRectTransform.DOScale(originalScale, _animationDuration)
            .SetEase(showEase).From(Vector3.zero)
            .OnComplete(() => {
                //Debug.Log("Panel shower "+gameObject.name+" completely");
            });
    }

    public void Hide()
    {
        _panelRectTransform.DOKill();
        
        _panelRectTransform.DOScale(Vector3.zero, _animationDuration)
            .SetEase(hideEase)
            .OnComplete(() => {
                gameObject.SetActive(false);
                //Debug.Log("Panel hidden "+gameObject.name+" completely");
            });
    }

    public void FastClose()
    {
        _panelRectTransform.DOKill();
        gameObject.SetActive(false);
    }
}

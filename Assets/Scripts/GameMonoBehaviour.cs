using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;


public enum SlideOrScale
{
    SCALEUP,
    SCALEDOWN,
    SLIDELEFTTORIGHT,
    SLIDERIGHTTOLEFT,
    SLIDEDOWNFROMUP,
    SLIDERUPFROMDOWN,
}

public class GameMonoBehaviour : MonoBehaviour
{
    public RectTransform panel;
    public float animationTime = 0.5f;
    public SlideOrScale selectAnimation;
    public UnityEvent OnAnimationShow;
    public UnityEvent OnAnimationHide;
    public Vector3 startAnimation;
    public Vector3 endAnimation;
    public bool isShown = false;
    public virtual void OnObjectEnable() { }
    public virtual void OnObjectDisable() { }
    private void OnEnable()
    {
        OnObjectEnable();
        Show();
    }

    public void Show()
    {
        if (isShown)
            return;

        switch (selectAnimation)
        {
            case SlideOrScale.SCALEUP:

                isShown = true;
                panel.localScale = startAnimation;
                gameObject.SetActive(isShown);
                panel.DOScale(endAnimation, animationTime).OnComplete(() =>
                {
                    OnAnimationShow.Invoke();
                });
                Debug.Log("Scaling up");
                break;

            case SlideOrScale.SCALEDOWN:
                // Handle scale down logic here
                Debug.Log("Scaling down");
                break;

            case SlideOrScale.SLIDELEFTTORIGHT:
                // Handle slide left to right logic here
                Debug.Log("Sliding from left to right");
                break;

            case SlideOrScale.SLIDERIGHTTOLEFT:
                isShown = true;
                panel.anchoredPosition = startAnimation;
                gameObject.SetActive(isShown);
                panel.DOAnchorPos3D(endAnimation, animationTime).OnComplete(() =>
                {
                    OnAnimationShow.Invoke();
                });
                break;

            case SlideOrScale.SLIDEDOWNFROMUP:
                // Handle slide down from up logic here
                Debug.Log("Sliding down from up");
                break;

            case SlideOrScale.SLIDERUPFROMDOWN:
                // Handle slide up from down logic here
                Debug.Log("Sliding up from down");
                break;

            default:
                break;
        }
    }

    public void ShowHide(bool check)
    {
        if (check)
            Show();
        else
            Hide();
    }
    private void OnDisable()
    {
        OnObjectDisable();
        Hide();
    }
    public void Hide()
    {
        if (!isShown)
            return;

        switch (selectAnimation)
        {
            case SlideOrScale.SCALEUP:
                isShown = false;
                panel.localScale = endAnimation;
                panel.DOScale(startAnimation, animationTime).OnComplete(() =>
                {
                    OnAnimationHide.Invoke();
                    gameObject.SetActive(false);
                });
                break;

            case SlideOrScale.SCALEDOWN:
                // Handle scale down logic here
                Debug.Log("Scaling down");
                break;

            case SlideOrScale.SLIDELEFTTORIGHT:
                // Handle slide left to right logic here
                Debug.Log("Sliding from left to right");
                break;

            case SlideOrScale.SLIDERIGHTTOLEFT:
                isShown = false;
                panel.anchoredPosition = endAnimation;
                panel.DOAnchorPos3D(startAnimation, animationTime).OnComplete(() =>
                {
                    OnAnimationHide.Invoke();
                    gameObject.SetActive(false);
                });
                break;

            case SlideOrScale.SLIDEDOWNFROMUP:
                // Handle slide down from up logic here
                Debug.Log("Sliding down from up");
                break;

            case SlideOrScale.SLIDERUPFROMDOWN:
                // Handle slide up from down logic here
                Debug.Log("Sliding up from down");
                break;

            default:
                break;
        }
    }
}

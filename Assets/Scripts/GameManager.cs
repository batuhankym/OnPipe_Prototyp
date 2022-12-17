using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ease MotionType;
    [SerializeField] private GameObject touchButton,titlePipeText,titleOnText,touchText,settingImage,gameManager;
    void Start()
    {
        touchButton.transform.DOMoveY(600f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);
    }
    
    public void TweenUIElements()
    {
        touchButton.transform.DOMoveX(-600f, 1f).SetEase(MotionType).SetUpdate(true);
        titlePipeText.transform.DOMoveX(1500f, 1f).SetEase(MotionType).SetUpdate(true);
        titleOnText.transform.DOMoveX(-600f, 1f).SetEase(MotionType).SetUpdate(true);
        touchText.transform.DOMoveY(-1600f, 1f).SetEase(MotionType).SetUpdate(true);
        settingImage.transform.DOMoveX(-600f, 1f).SetEase(MotionType).SetUpdate(true);

        
    }

    public void HideStarterUI()
    {
        gameManager.SetActive(false);
        
    }

  
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Cinemachine;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject confettiVFX;
    [SerializeField] private Transform firstVFXPos, secondVFXPos;
    public CinemachineVirtualCamera vcam;
    [SerializeField] private Ease MotionType;
    [SerializeField] private GameObject touchButton,titlePipeText,titleOnText,touchText,settingImage,scoreText,levelBar,levelCompleteText, completePanel,nextTouchImg;
    [FormerlySerializedAs("gameManager")] [SerializeField] private GameObject menuObjects;
    [SerializeField] private GameObject completeFollow;
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
        scoreText.transform.DOMoveX(195f, 1f).SetEase(MotionType).SetUpdate(true);
        levelBar.transform.DOMoveX(1012f, 1f).SetEase(MotionType).SetUpdate(true);


        
    }

    public void HideStarterUI()
    {
        menuObjects.SetActive(false);
        
    }

    public void LevelCompleteUI()
    {
        Instantiate(confettiVFX, firstVFXPos.position, Quaternion.identity);
        Instantiate(confettiVFX, secondVFXPos.position, Quaternion.identity);

        levelCompleteText.transform.DOMoveY(995f, 1f).SetEase(MotionType).SetUpdate(true);
        scoreText.transform.DOMoveX(-195f, 1f).SetEase(MotionType).SetUpdate(true);
        levelBar.transform.DOMoveX(-1012f, 1f).SetEase(MotionType).SetUpdate(true);
        nextTouchImg.transform.DOMoveX(700f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);

        completePanel.SetActive(true);
    }

    public void NewCamPos()
    {
        vcam.Follow = completeFollow.transform; 

    }


}

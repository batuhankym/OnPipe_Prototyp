using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
 [SerializeField] private Image uiFilledImage;
 
 private void Start()
 {
  uiFilledImage.fillAmount -= 1 * Time.deltaTime;
 }

 public void UpdateProgressFill(float value)
 {

  uiFilledImage.fillAmount +=0.1f / value;

 }
}

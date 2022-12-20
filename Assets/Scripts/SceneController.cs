using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  
  
  
  public void LoadNextScene()
  {
    SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings + 1);
  }

  public void RestartScene()
  {
    
  }
    
    
    
    
    
}

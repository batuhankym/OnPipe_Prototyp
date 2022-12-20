using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public LevelProgressUI levelProgressUI;

    public SceneController sceneController;
    private ScoreManager scoreClass;
    
    private int scoreToIncrease = 30;



    private Ease _motionType;

    private bool isComplete;
    private bool _isGameStart;

    private float _fillAmount = 1000f;
    
    public float radius = 5.0F; public float power = 10.0F; public float lift = 30; public float speed = 10;
    
    public bool explode = false;
    

    private void Start()
    {
        scoreClass = FindObjectOfType<ScoreManager>();

        sceneController.GetComponent<SceneController>();
        levelProgressUI.GetComponent<LevelProgressUI>();
        gameManager.GetComponent<GameManager>();
        _isGameStart = false;
    }

    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0 );

        if (Input.GetMouseButton(0))
        {
            switch (_isGameStart)
            {
                case false:
                    gameManager.TweenUIElements();
                    gameManager.Invoke(nameof(GameManager.HideStarterUI),1.5f);
                    _isGameStart = true;
                    break;
                case true:
                    transform.DOScale(1.5f, 0.5f);
                    break;
            }
            if (isComplete)
            {
                sceneController.LoadNextScene();
            
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.DOScale(3f, 0.5f);
        }
        
        if (explode)
        {
            scoreClass.IncreaseScore(scoreToIncrease);

            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.attachedRigidbody.CompareTag("Corn"))
                {


                    ControlProgress();
                    hit.attachedRigidbody.AddExplosionForce(power, explosionPos, radius, lift);
                    hit.attachedRigidbody.AddForce(Vector3.up * 10);
                    hit.attachedRigidbody.AddForce(-Vector3.forward * 10);
                    hit.gameObject.GetComponent<Collider>().isTrigger = false;
                    Destroy(hit.gameObject,0.5f);
                }
               
            }
        }

        

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Corn"))
        {
            explode = true;
            other.attachedRigidbody.isKinematic = false;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            isComplete = true;
            gameManager.LevelCompleteUI();
            gameManager.NewCamPos();
            transform.DOScale(3f, 0.5f);
            transform.Translate(0, speed * 50 * Time.deltaTime, 0 );


         




        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        explode = false;
    }
 

    private void ControlProgress()
    {
        levelProgressUI.UpdateProgressFill(_fillAmount);
    }
    
    
}

using System;
using TMPro;
using UnityEngine;

public class LifeUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    private float health = 3;
    

    private void Update()
    {
        health = HealthHandler.Instance.GetHealth();
        switch (health)
        {
            case 0:
                hearts[0].SetActive(false);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                hearts[3].SetActive(false);
                hearts[4].SetActive(false);
                hearts[5].SetActive(false);
                break; 
            case .5f:
                hearts[0].SetActive(true);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                hearts[3].SetActive(false);
                hearts[4].SetActive(false);
                hearts[5].SetActive(false);
                break; 
            case 1:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(false);
                hearts[3].SetActive(false);
                hearts[4].SetActive(false);
                hearts[5].SetActive(false);
                break; 
            case 1.5f:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                hearts[3].SetActive(false);
                hearts[4].SetActive(false);
                hearts[5].SetActive(false);
                break; 
            case 2:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                hearts[3].SetActive(true);
                hearts[4].SetActive(false);
                hearts[5].SetActive(false);
                break;
            case 2.5f:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                hearts[3].SetActive(true);
                hearts[4].SetActive(true);
                hearts[5].SetActive(false);
                break; 
            case 3:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                hearts[3].SetActive(true);
                hearts[4].SetActive(true);
                hearts[5].SetActive(true);
                break;
            default :
                break; 
                
        }
    }
    
    
}

using System;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public event Action playerDamaged;
    private PlayerGrospoint power;
    private bool powerOn = false; 

    private void Start()
    {
        power = FindAnyObjectByType<PlayerGrospoint>();
        power.powerOn += OnPowerOn; 
        power.powerOff += OnPoweroff; 
    }

    private void OnDestroy()
    {
        power.powerOn -= OnPowerOn;
        power.powerOff -= OnPoweroff;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("clyde")) && !powerOn)
        {
            playerDamaged?.Invoke();
            
            HealthHandler.Instance.UpdateHealth(-1); 
        }
    }

    private void OnPowerOn()
    {
        powerOn = true; 
    }
    
    private void OnPoweroff()
    {
        powerOn = false; 
    }
}

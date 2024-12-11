using System.Globalization;
using UnityEngine;
using System; 

public class PlayerScore : MonoBehaviour
{
    
    private string currentColTag;
    private PlayerGrospoint grospoint;
    private bool powerOn = false;
    public event Action clydeDead;
    public event Action ennemyDead; 

    private void Start()
    {
        grospoint = FindAnyObjectByType<PlayerGrospoint>(); 
        grospoint.powerOn += OnPowerOn; 
        grospoint.powerOff += OnPowerOff; 
    }

    private void OnDestroy()
    {
        grospoint.powerOn -= OnPowerOn;
        grospoint.powerOff -= OnPowerOff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentColTag = collision.gameObject.tag; 

        switch (currentColTag)
        {
            case "points":
                ScoreManager.Instance.UpdateScore(10);
                Destroy(collision.gameObject);  
                break;
            case "cerise":
                ScoreManager.Instance.UpdateScore(100);
                Destroy(collision.gameObject);
                break;
            case "orange":
                ScoreManager.Instance.UpdateScore(400);
                Destroy(collision.gameObject);
                break;
            case "enemy":
                if (powerOn)
                {
                    ScoreManager.Instance.UpdateScore(100);
                    ennemyDead?.Invoke();
                }                    
                break;
            case "clyde":
                if (powerOn)
                {
                    ScoreManager.Instance.UpdateScore(100);
                    clydeDead?.Invoke();    
                }
                break;
            default:
                break; 

        }
    }

    private void OnPowerOn()
    {
        powerOn = true;
    }
    private void OnPowerOff()
    {
        powerOn = false;
    }
}

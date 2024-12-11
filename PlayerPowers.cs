using System.Collections;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    private PlayersControl player;
    [SerializeField]private float ajoutSpeed = .5f;
    
    

    private void Start()
    {
        Time.timeScale = 1f; 
        player = GetComponent<PlayersControl>(); 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("speed"))
        {
            player.Speed += ajoutSpeed; 
            Destroy(collision.gameObject);
            StartCoroutine(nameof(ResetSpeed));
        }

        if (collision.gameObject.CompareTag("health"))
        {
            HealthHandler.Instance.UpdateHealth(.5f); 
            Destroy(collision.gameObject);
        }
    }

  

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(2); 
        player.Speed -= ajoutSpeed;
    }

    





}

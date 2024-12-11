using UnityEngine;
using System;
using System.Collections;

public class PlayerGrospoint : MonoBehaviour
{
    [SerializeField]private PlayersControl player;
    public event Action powerOn; 
    public event Action powerOff;
    [SerializeField] private float powerTime = 7f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("grospoints"))
        {           
            StartCoroutine("PowerCor");
            Destroy(other.gameObject);  
        }
    }

    IEnumerator PowerCor()
    {
        powerOn?.Invoke();
        player.Speed *= 1.2f;
        //faire du player power un observer et ativer ce pouvoir.
        yield return new WaitForSeconds(powerTime);     
        player.Speed /= 1.2f;  
        powerOff?.Invoke();
    }
}

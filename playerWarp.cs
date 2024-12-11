using UnityEngine;

public class playerWarp : MonoBehaviour
{
    private Transform trans;
    private Transform RTP;
    private Transform LTP;


    private void Start()
    {
        trans = GetComponent<Transform>();
        RTP = GameObject.Find("warpTPR").transform; //attention au nom 
        LTP = GameObject.Find("warpTPL").transform ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "warpR": 
                trans.position = LTP.position;
                break;
            case "warpL": 
                trans.position = RTP.position;
                break;
            default:
                break; 
        }

    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Clyde : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 currentPoint;
    [SerializeField] private Transform[] pathPoints; 
    private NavMeshAgent agent;
    [SerializeField] private PlayerDamageHandler damage;
    [SerializeField] private Transform basePoint;
    private PlayerGrospoint playerSubject;
    private bool powerOn = false;
    [SerializeField]private bool dead = false;
    [SerializeField] private Transform[] escapePoints;
    private PlayerScore playerScore;
    private Animator anim; 




    private void Start()
    {
        anim = GetComponent<Animator>();    
        playerSubject = FindAnyObjectByType<PlayerGrospoint>(); 
        playerScore = FindAnyObjectByType<PlayerScore>();   
        damage.playerDamaged += OnPlayerDamaged;
        playerScore.clydeDead += OnClydeDead;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentPoint = pathPoints[Random.Range(0, pathPoints.Length)].position;
        agent.destination = currentPoint;
        playerSubject.powerOn += OnPowerOn;
        playerSubject.powerOff += OnPowerOff;
    }

    private void Update()
    {

        if (!powerOn && !dead)
        {
            gameObject.GetComponent<Collider2D>().enabled = true; 
            DeplacementBase();
            //skindebase
        }
        else if (powerOn && !dead)
        {
            //apparence peur s
            agent.speed = 1.2f;
            int index = 0;
            float dist = Vector3.Distance(escapePoints[0].position, target.position);
            for (int i = 1; i < escapePoints.Length; i++)
            {
                if (Vector2.Distance(escapePoints[i].position, target.position) > dist)
                    index = i;
            }

            agent.SetDestination(escapePoints[index].position);
        }
        else if (dead) //mort 
        {
            agent.speed = 3;
            agent.SetDestination(basePoint.position);
            //skin mort
            if (Vector2.Distance(basePoint.position, transform.position) < 0.1f)
            {
                StartCoroutine("Wait");
                
            }


        }

        anim.SetBool("flee", powerOn);
        anim.SetBool("dead",dead);
    }

    private void OnDestroy()
    {
        damage.playerDamaged -= OnPlayerDamaged;
        playerScore.clydeDead -= OnClydeDead;
        playerSubject.powerOn -= OnPowerOn;
        playerSubject.powerOff -= OnPowerOff;
    }

    private void OnPlayerDamaged()
    {
        transform.position = basePoint.position;
        StartCoroutine("SpeedDelay"); 

    }

    IEnumerator SpeedDelay()
    {
        
        agent.speed = 0;
        yield return new WaitForSeconds(3f);
        agent.speed = 2; 
    }

    private void DeplacementBase()
    {
        
        if (Vector2.Distance(transform.position, currentPoint) < 0.5f)
        {
            currentPoint = pathPoints[Random.Range(0, pathPoints.Length)].position;
            agent.destination = currentPoint;
        }
    }

    private void OnPowerOn()
    {
        powerOn = true;
    }

    private void OnPowerOff()
    {
        powerOn = false;
        currentPoint = pathPoints[Random.Range(0, pathPoints.Length)].position;
        agent.destination = currentPoint;
        agent.speed = 2;

    }

    private void OnClydeDead()
    {
        dead = true;
        gameObject.GetComponent<Collider2D>().enabled = false; 

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        agent.speed = 2; currentPoint = pathPoints[Random.Range(0, pathPoints.Length)].position;
        agent.destination = currentPoint;
        dead = false;
    }
}

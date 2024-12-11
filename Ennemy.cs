using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System;
using Unity.VisualScripting;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    [SerializeField] private pathpointGenerator path;
    private int i = 0;
    private Transform currentPoint;
    [SerializeField]private Transform basePoint;
    [SerializeField] private bool Debug = false;
    private bool prewarm = false;
    [SerializeField] private bool followingpath = true;
    private ScoreManager score;
    [SerializeField] private PlayerDamageHandler damage;
    private bool pause = false; 
     private PlayerGrospoint playerSubject;
    private bool powerOn = false;
    private bool dead = false;
    [SerializeField] private Transform[] escapePoints;
    private PlayerScore playerScore;
    private Animator anim; 

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
                
                //agent.speed = vitesse de base; 
            }


        }

        anim.SetBool("flee", powerOn);
        anim.SetBool("dead", dead);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();    
        playerScore = FindAnyObjectByType<PlayerScore>();
        playerScore.ennemyDead += OnEnnemyDead; 
        damage.playerDamaged += OnPlayerDamaged; 
        score = FindAnyObjectByType<ScoreManager>();    
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (followingpath)
            StartCoroutine("StartCor"); 
        else 
            agent.SetDestination(target.position);
        playerSubject = FindAnyObjectByType<PlayerGrospoint>();
        playerSubject.powerOn += OnPowerOn;
        playerSubject.powerOff += OnPowerOff;

    }

   private void OnDestroy()
    {
        playerScore.ennemyDead -= OnEnnemyDead;
        playerSubject.powerOn -= OnPowerOn;
        playerSubject.powerOff -= OnPowerOff;
        damage.playerDamaged -= OnPlayerDamaged;
    }

    IEnumerator StartCor()
    {
        yield return new WaitForSeconds(6); 
        prewarm = true;
        if (path.pathPoints[i] != null)
        {
            currentPoint = path.pathPoints[i];
            agent.SetDestination(currentPoint.position);
            i++;
        }
    }  

    private void OnPlayerDamaged()
    {
        transform.position = basePoint.position;
        StartCoroutine("SpeedDelay"); 
    }

    IEnumerator SpeedDelay()
    {
        pause = true;
        float speed = agent.speed;
        agent.speed = 0;
        yield return new WaitForSeconds(1.5f);
        agent.speed = speed;
        pause = false;  
    }

    private void DeplacementBase()
    {
        if (score.Score > 1000 && score.Score <= 2000 && !pause)
            agent.speed = 2.5f;
        if (score.Score <= 1000 && !pause)
            agent.speed = 2f;
        if (score.Score > 2000 && score.Score <= 3000 && !pause)
            agent.speed = 3f;
        if (followingpath && prewarm)
        {
            try
            {
                if (Vector2.Distance(currentPoint.position, transform.position) < 0.1f && path.pathPoints[i] != null)
                {
                    currentPoint = path.pathPoints[i];
                    agent.SetDestination(currentPoint.position);
                    Destroy(path.pathPoints[i - 1].gameObject);
                    i++;
                }
            }
            catch (Exception e)
            {
                if (Debug)
                    print(e.ToString());
            }
        }
        else
            agent.SetDestination(target.position);
    }

    private void OnPowerOn()
    {
        powerOn = true;
    }

    private void OnPowerOff()
    {
        powerOn = false;
    }

    private void OnEnnemyDead()
    {
        dead = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        dead = false;
    }
}

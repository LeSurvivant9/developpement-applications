using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    // singleton : 

    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance(); 
            }
            return instance;
        }
    }    

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<ScoreManager>();
        if (instance == null)
        {
            GameObject created = new GameObject();
            created.name = "ScoreManager_Singleton"; 
             instance = created.AddComponent<ScoreManager>();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //fin singleton 

    //Variables : 
    private int score = 0;
    public int Score { get => score; set => score = value; }

    public int UpdateScore(int op)
    {
        score += op;    

        if (score < 0) //on fixe score >= 0 
        {
            score = 0; 
        }
        return score; 
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public int GetScore()
    {
        return score;   
    }
}



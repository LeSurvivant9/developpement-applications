using TMPro;
using UnityEngine;

public class ScoreDisplayHandler : MonoBehaviour
{
    [SerializeField]private TMP_Text text;
    private ScoreManager score;

    private void Start()
    {
        score = FindAnyObjectByType<ScoreManager>();
    }

    private void Update()
    {
        text.text = score.Score.ToString();
    }
}

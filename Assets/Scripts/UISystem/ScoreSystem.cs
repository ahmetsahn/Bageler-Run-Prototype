using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;

    [SerializeField]
     private TextMeshProUGUI scoreText;
     public int score { get; private set; }

   private void Awake()
   {
       if (Instance == null)
       {
           Instance = this;
       }
       else
       {
               Destroy(gameObject);
       }
   }

    private void OnEnable() => AddListeners();

    private void OnDisable() => RemoveListeners();

    private void UpdateScore(int value)
    {
         score += value;
    }

    private void PrintScore()
    {
       scoreText.text = "Score : " + score.ToString();
    }

    private void AddListeners()
    {
       GameEventsSystem.OnUpdateScoreInteractionBagel += UpdateScore;
       GameEventsSystem.OnUpdateScoreInteractionGate += UpdateScore;
       GameEventsSystem.OnPrintScore += PrintScore;
    }

    private void RemoveListeners()
    {
       GameEventsSystem.OnUpdateScoreInteractionBagel -= UpdateScore;
       GameEventsSystem.OnUpdateScoreInteractionGate -= UpdateScore;
       GameEventsSystem.OnPrintScore -= PrintScore;
    }
}

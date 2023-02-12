using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour,IInteractable
{
    
   [SerializeField] private enum GateType
        {
            PositiveGate,
            NegativeGate
        }

    [SerializeField] private TMP_Text gateText = null;
    [SerializeField] private GateType gateType;
    private int gateNumber;

    public int GetGateNumber()
    {
        return gateNumber;
    }

    private void Start()
    {
        GenerateRandomGateNumber();
    }

    private void GenerateRandomGateNumber()
    {
        switch (gateType)
        {
            case GateType.PositiveGate:
                gateNumber = Random.Range(1, 10);
                SetGateText();
                break;
            case GateType.NegativeGate:
                gateNumber = Random.Range(-10, -1);
                SetGateText();
                break;
        }
    }

    private void SetGateText()
    {
        gateText.text = gateNumber.ToString();
    }

    public void Interact()
    {

        switch (gateType)
        {
            case GateType.PositiveGate:
                
                GameEventsSystem.LoadUpdateScoreInteractionGate(gateNumber);
                GameEventsSystem.LoadInteractionPositiveGateSound();
                GameEventsSystem.LoadActiveBagelFromPool(gateNumber);
                GameEventsSystem.LoadSetCameraOffSet(gateNumber);
                GameEventsSystem.LoadPrintScore();
                break;
                
            case GateType.NegativeGate:
                
                if (ScoreSystem.Instance.score >= -gateNumber)
                {
                    GameEventsSystem.LoadUpdateScoreInteractionGate(gateNumber);
                    GameEventsSystem.LoadInteractionNegativeGateSound();
                    GameEventsSystem.LoadDeactiveBagelFromPool(-gateNumber);
                    GameEventsSystem.LoadSetCameraOffSet(-gateNumber);
                    GameEventsSystem.LoadPrintScore();
                }
                else
                {
                    GameEventsSystem.LoadGameOverSound();
                    GameEventsSystem.LoadPrintScore();
                }
              
                
                break;
        }
        
    }
}

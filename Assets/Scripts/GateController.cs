using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{
    
   [SerializeField] private enum GateType
        {
            PositiveGate,
            NegativeGate
        }

    [SerializeField] private TMP_Text gateText = null;
    [SerializeField] private GateType gateType;

    [SerializeField] private int gateNumber = 0;

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
}

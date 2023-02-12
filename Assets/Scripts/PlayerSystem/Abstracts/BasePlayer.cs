using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BasePlayer
{
    public virtual void EnterState(Player player)
    {
        
    }

    public virtual void FixedUpdate(Player player)
    {
        
    }

    public virtual void ExitState(Player player)
    {

    }
}

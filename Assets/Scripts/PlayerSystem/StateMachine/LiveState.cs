using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveState : BasePlayer
{
    
    public override void FixedUpdate(Player player)
    {
        player.playerMovement.Move(player.playerInput.horizontalInput);
        player.playerMovement.RangeControll();

        
    }

    public override void ExitState(Player player)
    {
        player.ChangeState(player.deadState);
    }

   
}

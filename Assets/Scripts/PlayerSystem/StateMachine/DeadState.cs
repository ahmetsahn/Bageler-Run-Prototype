using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BasePlayer
{
    public override void EnterState(Player player)
    {
        player.playerAnimation.playerAnimator.SetTrigger("Die");
    }
}

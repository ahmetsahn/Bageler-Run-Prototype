public class LiveState : BasePlayer
{
    public override void EnterState(Player player)
    {
        GameEventsSystem.OnDie += () => ExitState(player);
    }
    public override void FixedUpdate(Player player)
    {
        player.playerMovement.Move(player.playerInput.horizontalInput);
        player.playerMovement.RangeControll();
    }

    protected override void ExitState(Player player)
    {
        player.ChangeState(player.deadState);
    }
    
}

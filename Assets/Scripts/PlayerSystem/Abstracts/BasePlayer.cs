public abstract class BasePlayer
{
    public abstract void EnterState(Player player);
    

    public virtual void FixedUpdate(Player player)
    {
        
    }

    protected virtual void ExitState(Player player)
    {

    }
}

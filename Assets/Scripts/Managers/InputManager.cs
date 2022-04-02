using General;
using UnityEngine;

public class InputManager : Manager<InputPackage, InputManager>
{
    public override void Init()
    {

        base.Init();
    }
}

public class InputPackage : MonoBehaviour, IUpdaptable
{
    public void Init()
    {
        throw new System.NotImplementedException();
    }

    public void PostInit()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void FixedRefresh()
    {
        throw new System.NotImplementedException();
    }
}
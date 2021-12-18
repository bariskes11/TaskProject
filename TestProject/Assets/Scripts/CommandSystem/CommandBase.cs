using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Gen3eral command base for inheritance and adding general logics
/// </summary>
public class CommandBase : ICommand
{

    #region Protected Fields
    protected PlayerEconomy currentEconomy;
    protected float coinToOperate;
    #endregion
    public  virtual void Execute()
    {
        // base general logic to add
    }

    public virtual void Undo()
    {
        // base general logic to add
    }
}

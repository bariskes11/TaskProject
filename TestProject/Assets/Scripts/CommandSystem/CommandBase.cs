using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Gen3eral command base for inheritance and adding general logics
/// </summary>
public class CommandBase : ICommand
{

    #region Protected Fields
    protected PlayerCommands currentCommands;
    /// <summary>
    /// financial  can be coin/gem exc...
    /// </summary>
    protected float financialToOperate;
    #endregion

    public CommandBase(PlayerCommands _currentCommads, float _financialToOperate )
    {
        this.currentCommands = _currentCommads;
        this.financialToOperate = _financialToOperate;

    }
    public  virtual void Execute()
    {
        // base general logic to add
    }

    public virtual void Undo()
    {
        // base general logic to add
    }
}

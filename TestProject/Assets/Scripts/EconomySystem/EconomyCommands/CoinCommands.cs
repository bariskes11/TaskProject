using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCommands : ICommand
{
    #region Private Fields
    private PlayerEconomy currentEconomy;
    #endregion

    public CoinCommands(PlayerEconomy _currentEconomy)
    {
        this.currentEconomy = _currentEconomy;
    }
    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCommands : CommandBase
{

    public CoinCommands(PlayerEconomy _currentEconomy, float _coinToOperate)
    {
        this.currentEconomy = _currentEconomy;
        this.coinToOperate = _coinToOperate;
    }
    public override void Execute()
    {
        base.Execute();
        this.currentEconomy.CurrentCoinCount += this.coinToOperate;
        this.currentEconomy.TxtPlayerCoins.text = this.currentEconomy.CurrentCoinCount.ToString();
    }
    public override void Undo()
    {
        base.Undo();
        this.currentEconomy.CurrentCoinCount -= this.coinToOperate;
        this.currentEconomy.TxtPlayerCoins.text = this.currentEconomy.CurrentCoinCount.ToString();
    }
}

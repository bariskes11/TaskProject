using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCommands : CommandBase
{

    public CoinCommands(PlayerCommands currentCommands, float financeToOperate) : base(currentCommands, financeToOperate)
    { }
    
    public override void Execute()
    {
        base.Execute();
        this.currentCommands.CurrentCoinCount += this.financialToOperate;
        this.currentCommands.TxtPlayerCoins.text = this.currentCommands.CurrentCoinCount.ToString();
    }
    public override void Undo()
    {
        base.Undo();
        this.currentCommands.CurrentCoinCount -= this.financialToOperate;
        this.currentCommands.TxtPlayerCoins.text = this.currentCommands.CurrentCoinCount.ToString();
    }
}

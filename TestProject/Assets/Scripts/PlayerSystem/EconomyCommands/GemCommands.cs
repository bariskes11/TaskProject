using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCommands : CommandBase
{
    public GemCommands(PlayerCommands currentCommands, float financeToOperate) : base(currentCommands, financeToOperate)
    { }
    public override void Execute()
    {
        base.Execute();
        this.currentCommands.CurrentGemCount += this.financialToOperate;
        this.currentCommands.TxtPlayerGems.text = this.currentCommands.CurrentGemCount.ToString();
    }
    public override void Undo()
    {
        base.Undo();
        this.currentCommands.CurrentGemCount -= this.financialToOperate;
        this.currentCommands.TxtPlayerGems.text = this.currentCommands.CurrentGemCount.ToString();
    }


}

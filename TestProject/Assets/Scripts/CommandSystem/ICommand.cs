using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ICommand interface to  keep track of commands player made
/// </summary>
public interface ICommand 
{
    void Execute();
    void Undo();
}

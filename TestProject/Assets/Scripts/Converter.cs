using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// added for general converting
/// </summary>
public static class Converter
{
    public static string ConvertCurrencyToString(float val)
    {
        ///work around to not show Money symbols
        string result = val.ToString("C0");
        // removes money symbol
        return result.Substring(1, result.Length - 1);
    }
}

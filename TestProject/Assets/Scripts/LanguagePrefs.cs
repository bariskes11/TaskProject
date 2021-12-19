using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

/// <summary>
///  To get last saved language setting from Player Prefs
/// </summary>
public class LanguagePrefs 
{
    private const string LANGUAGE = "LANG";
    public string GetSavedLanguage()
    {
      return PlayerPrefs.GetString("LANG");
    }
    public void SetSavedLanguage(Languages language)
    {
        PlayerPrefs.SetString(LANGUAGE, language.ToString());
    }

    
}

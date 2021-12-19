using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LocalizationManager : MonoBehaviour
{

    #region Unity Fields
    [SerializeField]
    TextMeshProUGUI txtCurrentLanguage;
    [SerializeField]
    TextMeshProUGUI txtCurrentLanguageRead;

    #endregion
    #region Fields
    List<LocalizationTemplate> localizeList = new List<LocalizationTemplate>();
    #endregion



    public void SelectLanguage(PublicHardCodeds.Languages selectedLanguage)
    {
        switch (selectedLanguage)
        {
            case PublicHardCodeds.Languages.EN:

                break;
            case PublicHardCodeds.Languages.TR:
                break;
            case PublicHardCodeds.Languages.GR:
                break;
        }
    }


    #region Private Methods
    void ChangeLanguage(string code)
    { 
    
    }
    #endregion
}
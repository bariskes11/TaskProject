using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static PublicHardCodeds;

public class LocalizationManager : MonoBehaviour
{

    #region Unity Fields
    [SerializeField]
    TextMeshProUGUI txtCurrentLanguage;
    [SerializeField]
    TextMeshProUGUI txtCurrentLanguageRead;

    [SerializeField]
    Button btnEng;
    [SerializeField]
    Button btnTR;
    [SerializeField]
    Button btnGR;
    #endregion
    #region Fields
    List<LocalizationTemplate> localizeList = new List<LocalizationTemplate>();
    const string LOCALIZATION_PATH = "/StreamingAssets/LocalizationJsons";
    string path;
    LanguagePrefs languagePrefs = new LanguagePrefs();
    #endregion

    #region Unity Methods
    void Start()
    {
        // assets path for json object
        this.path = Application.dataPath + LOCALIZATION_PATH;

        if (btnEng == null || btnGR == null || btnTR == null)
        {
            Debug.Log($" <color=red> Please Add All Buttons</color>");
        }
        // added OnClick Listeners
        btnEng.onClick.AddListener(() => this.SelectLanguage(Languages.EN));
        btnGR.onClick.AddListener(() => this.SelectLanguage(Languages.GR));
        btnTR.onClick.AddListener(() => this.SelectLanguage(Languages.TR));
       var rslt=  languagePrefs.GetSavedLanguage();
        if (rslt == string.Empty) // there is no language setting  system language will be used
        {
            this.DefaultLanguageDecider();
        }
        else
        {
            // previous selected language
            this.ChangeLanguage(rslt);
        }
        

    }
    #endregion

    #region Private Methods
    void SelectLanguage(PublicHardCodeds.Languages selectedLanguage)
    {

        ChangeLanguage(selectedLanguage.ToString());
        this.languagePrefs.SetSavedLanguage(selectedLanguage);

    }
    void ChangeLanguage(string code)
    {
        DeserializeLanguageAndSetTexts(code);
    }

    void DeserializeLanguageAndSetTexts(string code)
    {
        string file = $"{this.path}/{code}.json";
        if (!File.Exists(file)) // there is no json file
        {
            Debug.Log($"<color=blue><b> Json File Not Found for  {code} file: {file}</b></color>");
            return;
        }
        else
        {
            StreamReader reader = new StreamReader(file);
            localizeList = JsonConverter.FromJson<LocalizationTemplate>(reader.ReadToEnd()).ToList();
            SetTextBasedOnLanguage();
            reader.Dispose();

        }
    }

    void SetTextBasedOnLanguage()
    {
        var currentlang = localizeList.Where(x => x.label == Languagelabels.CurrentLanguage.ToString()).FirstOrDefault();
        SetCurrentText(this.txtCurrentLanguage, currentlang.text, currentlang.RTL);


        var read = localizeList.Where(x => x.label == Languagelabels.Read.ToString()).FirstOrDefault();
        SetCurrentText(this.txtCurrentLanguageRead, read.text, read.RTL);


    }

    void SetCurrentText(TextMeshProUGUI txtObj, string txt, string rtl)
    {
        txtObj.text = txt;
        txtObj.isRightToLeftText = rtl == "1" ? true : false;
    }

    /// <summary>
    ///  This function decides initial language based on System language
    /// </summary>
    void DefaultLanguageDecider()
    {

        Debug.Log($"Current Language { Application.systemLanguage }");

        switch (Application.systemLanguage)
        {
            case SystemLanguage.Afrikaans:
                break;
            case SystemLanguage.Arabic:
                break;
            case SystemLanguage.Basque:
                break;
            case SystemLanguage.Belarusian:
                break;
            case SystemLanguage.Bulgarian:
                break;
            case SystemLanguage.Catalan:
                break;
            case SystemLanguage.Chinese:
                break;
            case SystemLanguage.Czech:
                break;
            case SystemLanguage.Danish:
                break;
            case SystemLanguage.Dutch:
                break;
            case SystemLanguage.English:
                this.ChangeLanguage(Languages.EN.ToString());
                break;
            case SystemLanguage.Estonian:
                break;
            case SystemLanguage.Faroese:
                break;
            case SystemLanguage.Finnish:
                break;
            case SystemLanguage.French:
                break;
            case SystemLanguage.German:
                this.ChangeLanguage(Languages.GR.ToString());
                break;
            case SystemLanguage.Greek:
                break;
            case SystemLanguage.Hebrew:
                break;
            case SystemLanguage.Hungarian:
                break;
            case SystemLanguage.Icelandic:
                break;
            case SystemLanguage.Indonesian:
                break;
            case SystemLanguage.Italian:
                break;
            case SystemLanguage.Japanese:
                break;
            case SystemLanguage.Korean:
                break;
            case SystemLanguage.Latvian:
                break;
            case SystemLanguage.Lithuanian:
                break;
            case SystemLanguage.Norwegian:
                break;
            case SystemLanguage.Polish:
                break;
            case SystemLanguage.Portuguese:
                break;
            case SystemLanguage.Romanian:
                break;
            case SystemLanguage.Russian:
                break;
            case SystemLanguage.SerboCroatian:
                break;
            case SystemLanguage.Slovak:
                break;
            case SystemLanguage.Slovenian:
                break;
            case SystemLanguage.Spanish:
                break;
            case SystemLanguage.Swedish:
                break;
            case SystemLanguage.Thai:
                break;
            case SystemLanguage.Turkish:
                this.ChangeLanguage(Languages.TR.ToString());
                break;
            case SystemLanguage.Ukrainian:
                break;
            case SystemLanguage.Vietnamese:
                break;
            case SystemLanguage.ChineseSimplified:
                break;
            case SystemLanguage.ChineseTraditional:
                break;
            case SystemLanguage.Unknown:
                break;
            
        }
    }

    #endregion
}
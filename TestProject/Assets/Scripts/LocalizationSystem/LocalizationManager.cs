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
    }
    #endregion

    #region Private Methods
    void SelectLanguage(PublicHardCodeds.Languages selectedLanguage)
    {
        ChangeLanguage(selectedLanguage.ToString());
    }
    void ChangeLanguage(string code)
    {
        DeserializeLanguageAndSetTexts(code);
    }

    void DeserializeLanguageAndSetTexts(string code)
    {
        string file=  $"{this.path}/{code}.json";
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
    #endregion
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Generates Desired item with all properties
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    #region Unity Fields
    [Header("Creates Item with selected Images And Orices")]
    [Header("---------")]
    [Space()]
    [Header("Currency Banner Image Field")]
    [SerializeField]
    Image imgCurrencyBanner;

    [Header("Currency Banner")]
    [SerializeField]
    Sprite currencyBanner;

    [Header("Currency Banner Icon Field")]
    [SerializeField]
    Image imgcurrencyIcon;

    [Header("Currency Icon")]
    [SerializeField]
    Sprite currencyIcon;
    [Header("Currency Value Text")]
    [SerializeField]
    TextMeshProUGUI txtCurrencyPrice;

    [Header("Currency Value")]
    [SerializeField]
    float currencyValue;

    [Header("Currency Exp Text")]
    [SerializeField]
    TextMeshProUGUI txtExp;
    [Header("Currency Exp string")]
    [SerializeField]
    string expString = "1h of Double EXP";

    [Header("Currency Buy Price Text")]
    [SerializeField]
    TextMeshProUGUI txtItemBuyPrice;
    [Header("Currency Buy Price")]
    [SerializeField]
    float itemBuyValue;
    #endregion

    #region Properties
    public float CurrencyValue
    {
        get => this.currencyValue;
    }
    #endregion


    #region Unity Methods
    private void Start()
    {
        this.SetInitialValues();
    }
    #endregion

    #region Private Methods

    [ContextMenu("Create Template")]
    void SetInitialValues()
    {
        this.imgCurrencyBanner.sprite = this.currencyBanner;
        if (this.currencyIcon != null)
        {
            this.imgcurrencyIcon.sprite = this.currencyIcon;
        }
        else
        {
            this.imgcurrencyIcon.enabled = false;
        }
        ///work around to not show Money symbols
        string result = this.currencyValue.ToString("C0");
        this.txtCurrencyPrice.text = result.Substring(1, result.Length - 1);
        this.txtItemBuyPrice.text = $"${this.itemBuyValue.ToString("0.00")} USD";
        this.txtExp.text = this.expString;
    }


    #endregion




}

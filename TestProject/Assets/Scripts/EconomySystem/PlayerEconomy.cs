using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
///  Script is to keep track of player main economy
///  Keep Track of  owned items
/// </summary>
public class PlayerEconomy : MonoBehaviour
{
    #region Unity Fields
    [Header("Special Offer Gift Images List")]
    [SerializeField]
    GameObject specialOfferBanner;
    [SerializeField]
    GameObject specialOfferImage;
    [SerializeField]
    GameObject specialOfferGiftImage;

    [Header("---------")]
    [Space()]

    [Header("Player Currency Texts")]

    [SerializeField]
    TextMeshProUGUI txtPlayerCoins;
    [SerializeField]
    TextMeshProUGUI txtPlayerGems;
    [SerializeField]
    [Header("Set's the number of special offer count after this number reached speacial offer will be disabled")]
    int specialOfferBuyCount = 1;
    [Header("---------")]
    [Space()]
    #endregion
    #region Fields
    // list of current game Commands
    CommandList cmds = new CommandList();
    #endregion
    #region Fields
    int currentSpecialOffer = 0;
    #endregion


    #region Properties
    private float currentCoinCount;
    public float CurrentCoinCount
    {
        get => this.currentCoinCount;
        set => this.currentCoinCount = value;
    }
    private float currentGemCount;
    public float CurrentGemCount
    {
        get => this.currentGemCount;
        set => this.currentGemCount = value;
    }
    public TextMeshProUGUI TxtPlayerCoins
    {
        get => this.txtPlayerCoins;
        set => this.txtPlayerCoins=value;


    }
    public TextMeshProUGUI TxtPlayerGems
    {
        get => this.txtPlayerGems;
        set => this.txtPlayerGems = value;
    }

    #endregion

    #region Unity Methods
    private void Start()
    {
        if (txtPlayerCoins == null)
            Debug.Log($"<color=red> There is No Player Coin text </color>");
        if (txtPlayerGems == null)
            Debug.Log($"<color=red> There is No Player Gem text </color>");

        this.currentCoinCount =float.Parse( this.txtPlayerCoins.text);
        this.currentGemCount = float.Parse(this.txtPlayerGems.text);
        this.specialOfferBuyCount = this.currentSpecialOffer;
    }

    #endregion

    #region Public Methods
    public void BuyCoin(float addedCount)
    {
        if (this.currentSpecialOffer >= 0)
        {
            this.currentSpecialOffer -= 1;
            addedCount *= 2; // double  the win if special offer count is large then zero
        }
        else
        {
            this.DisableSpecialOfferBanner();
        }
        cmds.Execute(new CoinCommands(this, addedCount));
    }

    public void BuyGem(float addedCount)
    { 
    
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// hides banner when there is no special offer
    /// </summary>
    void DisableSpecialOfferBanner()
    {
        this.specialOfferGiftImage.SetActive(false);
        this.specialOfferImage.SetActive(false);
        this.specialOfferBanner.SetActive(false);
            

    }
    #endregion




}

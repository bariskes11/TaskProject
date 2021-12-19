using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Script is to keep track of player main economy
///  Keep Track of  owned items
/// </summary>
public class PlayerCommands : MonoBehaviour
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
    Text txtPlayerCoins;
    [SerializeField]
    Text txtPlayerGems;
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
    public Text TxtPlayerCoins
    {
        get => this.txtPlayerCoins;
        set => this.txtPlayerCoins=value;


    }
    public Text TxtPlayerGems
    {
        get => this.txtPlayerGems;
        set => this.txtPlayerGems = value;
    }
    private Vector3 lastPos;
    public Vector3 LastPos
    {
        get => this.lastPos;
        set => this.lastPos = value;

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
        this.currentSpecialOffer = this.specialOfferBuyCount;
    }

    #endregion

    #region Public Methods
    public void BuyCoin(float addedCount,GameObject button)
    {
        
        addedCount = this.DecideOffer(addedCount);
        cmds.Execute(new CoinCommands(this, addedCount));
        EventManager.OnOwnedItem.Invoke(PublicHardCodeds.FinancialTypes.Coin, button);
    }

    public void BuyGem(float addedCount, GameObject button)
    {
        
        addedCount = this.DecideOffer(addedCount);
        cmds.Execute(new GemCommands(this, addedCount));
        EventManager.OnOwnedItem.Invoke(PublicHardCodeds.FinancialTypes.Gem, button);

    }
    #endregion
    #region Private Methods
    float DecideOffer(float financial)
    {
        
        if (this.currentSpecialOffer > 0)
        {
            financial *= 2; // double  the win if special offer count is large then zero
            this.currentSpecialOffer -= 1;// decreiseoffer count
        }
        
        if(this.currentSpecialOffer<=0) // no offer left
        {
            this.DisableSpecialOfferBanner();
        }

        return financial;
    }
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

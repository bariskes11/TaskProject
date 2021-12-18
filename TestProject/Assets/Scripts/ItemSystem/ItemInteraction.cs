using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  sets interaction for gem or coin object
/// </summary>
[RequireComponent(typeof(ItemGenerator))]
public class ItemInteraction : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    PublicHardCodeds.FinancialTypes financeType=PublicHardCodeds.FinancialTypes.Coin;

    #endregion

    #region Fields
    ItemGenerator itemgenerator;
    Button buyButton;
    PlayerCommands player;
    #endregion
    #region Unity Methods

    

    void Start()
    {
        itemgenerator = this.GetComponent<ItemGenerator>();
        buyButton = this.GetComponentInChildren<Button>();
        player = FindObjectOfType<PlayerCommands>();
        if (player == null)
        {
            Debug.Log($"<color=red>There is no Player in Scene!!</color>");
        }


        if (buyButton == null)
            Debug.Log($"<color=red> There is no Buy Button in template Buy won't work");

        buyButton.onClick.AddListener(this.BuyFinancial);
    }
    #endregion
    #region Private Methods
    void BuyFinancial()
    {

        Debug.Log($"Player clicked on {this.itemgenerator.CurrencyValue} financialType {this.financeType}");
        switch (this.financeType) // decide financial type send command to player
        {
            case PublicHardCodeds.FinancialTypes.Coin:
                player.BuyCoin(this.itemgenerator.CurrencyValue);
                break;
            case PublicHardCodeds.FinancialTypes.Gem:
                player.BuyGem(this.itemgenerator.CurrencyValue);
                break;
            
        }
    }

    #endregion


    // Update is called once per frame


}

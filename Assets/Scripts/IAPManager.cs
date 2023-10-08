using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
public class IAPManager : MonoBehaviour
{

    private string noads = "com.hypersengames.officeworker.noads";
    private GameObject iapbtn;

    [SerializeField]
    private bool _purchased;

    public bool purchased
    {
        get { return _purchased; }
        set
        {
            _purchased = value;
            PlayerPrefs.SetInt("Purchased", value ? 1 : 0);
        }
    }

    private void Awake()
    {
        // Initialize the purchased state from PlayerPrefs
        purchased = PlayerPrefs.GetInt("Purchased", 0) == 1;

        iapbtn = GameObject.FindGameObjectWithTag("noadsbtn");

        // Disable the button if the product has already been purchased
        if (purchased)
        {
            iapbtn.SetActive(false);
        }
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == noads)
        {
            purchased = true;
            iapbtn.SetActive(false);

            // Save the purchased state in PlayerPrefs
            PlayerPrefs.Save();
        }
    }



}

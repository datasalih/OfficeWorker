using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class AdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";

    string _adUnitId;
    [SerializeField] Button _showAdButton;
    public int admoney = 150;
    private GameObject adbtn;
    public CollectManager collectmanager;
    public Text AdMoneyText;
    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Disable the button until the ad is ready to show:
        _showAdButton.interactable = false;

    }

    private void Update()
    {
        UpdateAdMoney();
    }

    private void Start()
    {
        Advertisement.Load(_adUnitId, this);
        LoadAd();

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        Advertisement.Load(_adUnitId, this);
    }

    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
        _showAdButton.interactable = true;

    }




    public void ShowRewardedAd()
    {

        Advertisement.Show(_adUnitId, this);
        adbtn = GameObject.FindGameObjectWithTag("AdButton");
        adbtn.GetComponent<Button>().interactable = false;


        UpdateAdMoney();
        PlayerPrefs.SetInt("Money", collectmanager.moneyCount);
        PlayerPrefs.Save();



        // Display the rewarded message
        Debug.Log("Reward earned! Current word updated. Correct counter incremented.");
    }

    public void ShowInsAd()
    {
       
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowRewardedAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }
 

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            collectmanager.moneyCount += admoney;
            collectmanager.moneyText.text = collectmanager.moneyCount.ToString();

            PlayerPrefs.SetInt("Money", collectmanager.moneyCount);
            PlayerPrefs.Save();

        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {

        PlayerPrefs.SetInt("Money", collectmanager.moneyCount);
        PlayerPrefs.Save();

        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }


    void UpdateAdMoney()
    {
        if (collectmanager.moneyCount < 1000)
        {
            admoney = 150;
            AdMoneyText.text = "+" + admoney;

        }
        else if (collectmanager.moneyCount >= 1000 && collectmanager.moneyCount < 2000)
        {
            admoney = 200;
            AdMoneyText.text = "+" + admoney;

        }
        else if (collectmanager.moneyCount >= 2000 && collectmanager.moneyCount < 3000)
        {
            admoney = 300;
            AdMoneyText.text = "+" + admoney;

        }
        else if (collectmanager.moneyCount >= 3000 && collectmanager.moneyCount < 5000)
        {
            admoney = 400;
            AdMoneyText.text = "+" + admoney;

        }
        else if (collectmanager.moneyCount >= 5000)
        {
            admoney = 500;
            AdMoneyText.text = "+" + admoney;

        }


    }





}

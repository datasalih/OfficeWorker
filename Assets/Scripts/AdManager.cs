using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{


    RewardedAd rewardedAd;
    private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
    private GameObject adbtn;

    public CollectManager collectmanager;

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            LoadRewardedAd();
        });

        adbtn = GameObject.FindGameObjectWithTag("AdButton");

    }

    public void LoadRewardedAd()
    {
        if (rewardedAd != null)
        {
            DestroyAd();
        }


        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error.GetMessage());
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
                RegisterEventHandlers(rewardedAd);
            });
    }


    public void ShowRewardedAd()
    {


        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                adbtn = GameObject.FindGameObjectWithTag("AdButton");
                adbtn.GetComponent<Button>().interactable = false;

                collectmanager.moneyCount += 100;
                collectmanager.moneyText.text = collectmanager.moneyCount.ToString();

                PlayerPrefs.SetInt("Money", collectmanager.moneyCount);
                PlayerPrefs.Save();



                // Display the rewarded message
                Debug.Log("Reward earned! Current word updated. Correct counter incremented.");
            });

        }
        else
        {
            Debug.Log("Not Ready");
        }
    }

    public void DestroyAd()
    {
        if (rewardedAd != null)
        {
            Debug.Log("Destroying rewarded ad.");
            rewardedAd.Destroy();
            rewardedAd = null;
        }

    }



    private void RegisterEventHandlers(RewardedAd ad)
    {

    }


}




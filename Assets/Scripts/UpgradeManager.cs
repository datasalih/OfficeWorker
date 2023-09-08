using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{

    int moneyLimitUpgrade = 15;
    int collectLimitUpgrade = 15;
    public PrinterManager printermanager;
    public PrinterManager1 printermanager1;
    public PrinterManager2 printermanager2;
    public CollectManager collectManager;
   
    public Movement movement;

    public int paperprice = 100;
    public int collectprice = 100;
    public int moneyprice = 500;
    public int unlockPrice = 1000;
    public int unlockPrice1 = 2000;
    public Text paperpriceText;
    public Text collectpriceText;
    public Text moneypriceText;

    private GameObject Unlockables;
    public GameObject UnlockButtons;

    private GameObject UnlockPrinterPrefab;
    private GameObject UnlockWorkerPrefab;
    private GameObject UnlockPrinter1Prefab;
    private GameObject UnlockWorker1Prefab;

    public bool printerUnlocked;
    public bool workerUnlocked;
    public bool printer1Unlocked;
    public bool worker1Unlocked;


    private void Start()
    {

        paperprice = PlayerPrefs.GetInt("paperupgrade", paperprice);
        collectprice = PlayerPrefs.GetInt("collectlimit", collectprice);
        moneyprice = PlayerPrefs.GetInt("moneyprice", moneyprice);


        paperpriceText.text = paperprice.ToString() + "$";
        collectpriceText.text = collectprice.ToString() + "$";
        moneypriceText.text = moneyprice.ToString() + "$";

        UnlockButtons = GameObject.FindGameObjectWithTag("UnlockButtons");

        Unlockables = GameObject.FindGameObjectWithTag("Unlockables");
        UnlockPrinterPrefab = GameObject.FindGameObjectWithTag("UnlockPrinter");
        UnlockWorkerPrefab = GameObject.FindGameObjectWithTag("UnlockWorker");
        UnlockPrinter1Prefab = GameObject.FindGameObjectWithTag("UnlockPrinter1");
        UnlockWorker1Prefab = GameObject.FindGameObjectWithTag("UnlockWorker1");

        printerUnlocked = PlayerPrefs.GetInt("printerunlocked", 0) == 1;
        workerUnlocked = PlayerPrefs.GetInt("workerunlocked", 0) == 1;
        printer1Unlocked = PlayerPrefs.GetInt("printerunlocked1", 0) == 1;
        worker1Unlocked = PlayerPrefs.GetInt("workerunlocked1", 0) == 1;

        if (printerUnlocked==true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(UnlockPrinterPrefab);

            }

            if (printerUnlocked)
            {
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(false);

            }
        }

        if (workerUnlocked==true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(UnlockWorkerPrefab);
            }

            if (workerUnlocked)
            {
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(false);

            }
        }

        if (printer1Unlocked == true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(2).gameObject.SetActive(true);
                Destroy(UnlockPrinter1Prefab);

            }

            if (printer1Unlocked)
            {
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(false);

            }
        }

        if (worker1Unlocked == true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(3).gameObject.SetActive(true);
                Destroy(UnlockWorker1Prefab);
            }

            if (worker1Unlocked)
            {
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(false);

            }
        }
    }


    public void UpgradePaperLimit()
    {
        movement.movementSpeed = 0;
        movement.rotationSpeed = 0;

        StartCoroutine(ResetMovementSpeedAfterDelay(5f));


        if (collectManager.moneyCount >= paperprice)
        {
            collectManager.moneyCount -= paperprice;
            paperprice *= 2;
            paperpriceText.text = paperprice.ToString() + "$";

            printermanager.paperLimit += moneyLimitUpgrade;
            printermanager1.paperLimit += moneyLimitUpgrade;
            printermanager2.paperLimit += moneyLimitUpgrade;
            
            
            UpdateMoneyText();
            PlayerPrefs.SetInt("paper", paperprice);
            PlayerPrefs.Save();


            movement.movementSpeed = 0;

            // Call a function to reset the movement speed after a delay (e.g., 2 seconds)
            StartCoroutine(ResetMovementSpeedAfterDelay(2f));
        }
    }

    public void UpgradeCollectLimit()
    {
          movement.movementSpeed = 0;
        movement.rotationSpeed = 0;


        StartCoroutine(ResetMovementSpeedAfterDelay(5f));

        if (collectManager.moneyCount >= collectprice)
        {
            collectManager.moneyCount -= collectprice;
            collectprice *= 2;
            collectpriceText.text = collectprice.ToString() + "$";

            collectManager.collectLimit += collectLimitUpgrade;
            UpdateMoneyText();
            PlayerPrefs.SetInt("collect", collectprice);
            PlayerPrefs.Save();


            movement.movementSpeed = 0;

            // Call a function to reset the movement speed after a delay (e.g., 2 seconds)
            StartCoroutine(ResetMovementSpeedAfterDelay(2f));
        }

    }

    public void UpgradeMoneyValue()
    {
        movement.movementSpeed = 0;
        movement.rotationSpeed = 0;


        StartCoroutine(ResetMovementSpeedAfterDelay(5f));

        if (collectManager.moneyCount >= moneyprice)
        {
            collectManager.moneyCount -= moneyprice;
            moneyprice *=2;
            moneypriceText.text = moneyprice.ToString() + "$";

            collectManager.moneyValue *= 2;
            UpdateMoneyText();
            PlayerPrefs.SetInt("moneyprice", moneyprice);
            PlayerPrefs.Save();


            movement.movementSpeed = 0;

            // Call a function to reset the movement speed after a delay (e.g., 2 seconds)
            StartCoroutine(ResetMovementSpeedAfterDelay(2f));
        }

    }


    private void UpdateMoneyText()
    {
        collectManager.moneyText.text = collectManager.moneyCount.ToString();
    }


    private IEnumerator ResetMovementSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        movement.rotationSpeed = 500;
        movement.movementSpeed = 10;
        // Replace '10' with the original movement speed value
    }

    public void UnlockPrinter()
    {
        if (collectManager.moneyCount >= unlockPrice)
        {
            printerUnlocked= true;
            collectManager.moneyCount -= unlockPrice;
            UpdateMoneyText();

            PlayerPrefs.SetInt("printerunlocked", 1);
            PlayerPrefs.Save();

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Destroy(UnlockPrinterPrefab);
                Unlockables.transform.GetChild(0).gameObject.SetActive(true);
            }

            if(printerUnlocked)
            {
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(false);

            }

        }
    }

    public void UnlockWorker()
    {
        if (collectManager.moneyCount >= unlockPrice)
        {
            workerUnlocked = true;
            collectManager.moneyCount -= unlockPrice;
            UpdateMoneyText();

            PlayerPrefs.SetInt("workerunlocked", 1);
            PlayerPrefs.Save();

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(UnlockWorkerPrefab);
            }

            if (workerUnlocked)
            {
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(false);

            }

        }
    }

    public void UnlockPrinter1()
    {
        if (collectManager.moneyCount >= unlockPrice1)
        {
            printer1Unlocked = true;
            collectManager.moneyCount -= unlockPrice1;
            UpdateMoneyText();

            PlayerPrefs.SetInt("printerunlocked1", 1);
            PlayerPrefs.Save();

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Destroy(UnlockPrinter1Prefab);
                Unlockables.transform.GetChild(2).gameObject.SetActive(true);
            }

            if (printer1Unlocked)
            {
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(false);

            }

        }
    }

    public void UnlockWorker1()
    {
        if (collectManager.moneyCount >= unlockPrice1)
        {
            worker1Unlocked = true;
            collectManager.moneyCount -= unlockPrice1;
            UpdateMoneyText();

            PlayerPrefs.SetInt("workerunlocked1", 1);
            PlayerPrefs.Save();

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(3).gameObject.SetActive(true);
                Destroy(UnlockWorker1Prefab);
            }

            if (worker1Unlocked)
            {
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(false);

            }

        }
    }


    private void OnDestroy()

    {
        PlayerPrefs.SetInt("paperupgrade", paperprice);
        PlayerPrefs.SetInt("collectlimit", collectprice);
        PlayerPrefs.SetInt("moneyprice", moneyprice);
        PlayerPrefs.Save();
    }

}

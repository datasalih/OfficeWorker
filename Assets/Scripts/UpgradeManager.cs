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
    public insad admanager;
   
    public Movement movement;
    public int paperprice = 100;
    public int collectprice = 100;
    public int moneyprice = 500;
    public int employeeprice = 500;

    public int unlockPrice = 1000;
    public int unlockPrice1 = 2000;
    public Text paperpriceText;
    public Text collectpriceText;
    public Text moneypriceText;
    public Text employeepriceText;

    public GameObject Unlockables;
    public GameObject UnlockButtons;
    public GameObject UpgradeButtons;

    public GameObject UnlockPrinterPrefab;
    public GameObject UnlockWorkerPrefab;
    public GameObject UnlockPrinter1Prefab;
    public GameObject UnlockWorker1Prefab;

    public bool printerUnlocked;
    public bool workerUnlocked;
    public bool printer1Unlocked;
    public bool worker1Unlocked;
    public bool employee1Unlocked;
    public bool employee2Unlocked;
    public bool employee3Unlocked;


    private void Start()
    {


        paperprice = PlayerPrefs.GetInt("PaperPrice", paperprice);
        collectprice = PlayerPrefs.GetInt("CollectPrice", collectprice);
        moneyprice = PlayerPrefs.GetInt("MoneyPrice", moneyprice);
        employeeprice = PlayerPrefs.GetInt("employeePrice", employeeprice);

        paperpriceText.text = paperprice.ToString() + "$";
        collectpriceText.text = collectprice.ToString() + "$";
        moneypriceText.text = moneyprice.ToString() + "$";
        employeepriceText.text = employeeprice.ToString() + "$";

        UnlockButtons = GameObject.FindGameObjectWithTag("UnlockButtons");
        UpgradeButtons = GameObject.FindGameObjectWithTag("UpgradeButtons");
        Unlockables = GameObject.FindGameObjectWithTag("Unlockables");
        UnlockPrinterPrefab = GameObject.FindGameObjectWithTag("UnlockPrinter");
        UnlockWorkerPrefab = GameObject.FindGameObjectWithTag("UnlockWorker");
        UnlockPrinter1Prefab = GameObject.FindGameObjectWithTag("UnlockPrinter1");
        UnlockWorker1Prefab = GameObject.FindGameObjectWithTag("UnlockWorker1");

        printerUnlocked = PlayerPrefs.GetInt("printerunlocked", 0) == 1;
        workerUnlocked = PlayerPrefs.GetInt("workerunlocked", 0) == 1;
        printer1Unlocked = PlayerPrefs.GetInt("printerunlocked1", 0) == 1;
        worker1Unlocked = PlayerPrefs.GetInt("workerunlocked1", 0) == 1;
        employee1Unlocked = PlayerPrefs.GetInt("employeeUnlocked1", 0) == 1;
        employee2Unlocked = PlayerPrefs.GetInt("employeeUnlocked2", 0) == 1;
        employee3Unlocked = PlayerPrefs.GetInt("employeeUnlocked3", 0) == 1;


        if (printerUnlocked==true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(UnlockPrinterPrefab);
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(false);

            }

           
        }

    

        if (workerUnlocked==true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(UnlockWorkerPrefab);
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(false);

            }
        }

        if (printer1Unlocked == true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(2).gameObject.SetActive(true);
                Destroy(UnlockPrinter1Prefab);
                 UnlockButtons.transform.GetChild(2).gameObject.SetActive(false);

                
            }

      
        }

        if (worker1Unlocked == true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(3).gameObject.SetActive(true);
                Destroy(UnlockWorker1Prefab);
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(false);

            }



        }


        if (employee1Unlocked == true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(4).gameObject.SetActive(true);
            }
        }

        if (employee2Unlocked == true)
        {
            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(5).gameObject.SetActive(true);
            }
        }

        if (employee3Unlocked == true)
        {

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(6).gameObject.SetActive(true);

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
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);
            PlayerPrefs.SetInt("PaperPrice", paperprice);
            PlayerPrefs.SetInt("PaperLimit", printermanager.paperLimit);
            PlayerPrefs.Save();


            movement.movementSpeed = 0;

            StartCoroutine(ResetMovementSpeedAfterDelay(2f));
            admanager.ShowAd();
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
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);
            PlayerPrefs.SetInt("CollectLimit",collectManager.collectLimit);
            PlayerPrefs.SetInt("CollectPrice", collectprice);
            PlayerPrefs.Save();


            movement.movementSpeed = 0;

            // Call a function to reset the movement speed after a delay (e.g., 2 seconds)
            StartCoroutine(ResetMovementSpeedAfterDelay(2f));
            admanager.ShowAd();

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
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);
            PlayerPrefs.SetInt("MoneyValue", collectManager.moneyValue);
            PlayerPrefs.SetInt("MoneyPrice", moneyprice);
            PlayerPrefs.Save();


            movement.movementSpeed = 0;

            // Call a function to reset the movement speed after a delay (e.g., 2 seconds)
            StartCoroutine(ResetMovementSpeedAfterDelay(2f));
            admanager.ShowAd();

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
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);

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
            admanager.ShowAd();

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
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);

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
            admanager.ShowAd();

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
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);

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
            admanager.ShowAd();

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
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);

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
            admanager.ShowAd();

        }
    }

    public void UnlockEmployee()
    {
        if (collectManager.moneyCount >= employeeprice && !employee1Unlocked)
        {
            employee1Unlocked = true;
            collectManager.moneyCount -= employeeprice;
            employeeprice *= 2;
            employeepriceText.text = employeeprice.ToString() + "$";

            UpdateMoneyText();

            PlayerPrefs.SetInt("employeeUnlocked1", 1);
            PlayerPrefs.SetInt("employeePrice", employeeprice);
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);
            PlayerPrefs.Save();

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(4).gameObject.SetActive(true);
            }
            admanager.ShowAd();
        }

       else if (collectManager.moneyCount >= employeeprice && employee1Unlocked && !employee2Unlocked)
        {
            employee2Unlocked = true;
            collectManager.moneyCount -= employeeprice;
            employeeprice *= 2;
            employeepriceText.text = employeeprice.ToString() + "$";

            UpdateMoneyText();

            PlayerPrefs.SetInt("employeeUnlocked2", 1);
            PlayerPrefs.SetInt("employeePrice", employeeprice);
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);
            PlayerPrefs.Save();

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(5).gameObject.SetActive(true);
            }

          

            admanager.ShowAd();
        }

       else if (collectManager.moneyCount >= employeeprice && employee2Unlocked && !employee3Unlocked)
        {
            employee3Unlocked = true;
            collectManager.moneyCount -= employeeprice;
            UpdateMoneyText();

            PlayerPrefs.SetInt("employeeUnlocked3", 1);
            PlayerPrefs.SetInt("Money", collectManager.moneyCount);
            PlayerPrefs.Save();

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(6).gameObject.SetActive(true);
            }

            if (employee3Unlocked)
            {
                UpgradeButtons.transform.GetChild(3).gameObject.SetActive(false);
            }

            admanager.ShowAd();
        }
    }


    private void OnDestroy()
    {
        PlayerPrefs.SetInt("PaperPrice", paperprice);
        PlayerPrefs.SetInt("CollectPrice", collectprice);
        PlayerPrefs.SetInt("MoneyPrice", moneyprice);

        PlayerPrefs.SetInt("MoneyValue", collectManager.moneyValue);
        PlayerPrefs.SetInt("PaperLimit", printermanager.paperLimit);
        PlayerPrefs.SetInt("CollectLimit", collectManager.collectLimit);
        PlayerPrefs.SetInt("Money", collectManager.moneyCount);

        PlayerPrefs.Save();
    }

}

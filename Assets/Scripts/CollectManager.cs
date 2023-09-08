using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CollectManager : MonoBehaviour
{

    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform collectPoint;
    public PrinterManager printerManager;
    public PrinterManager1 printerManager1;
    public PrinterManager2 printerManager2;
    public MoneyManager moneyManager;
    public MoneyManager1 moneyManager1;
    public MoneyManager2 moneyManager2;
    public UpgradeManager upgradeManager;
    public GameObject UpgradeButtons;
    public GameObject UnlockButtons;

    public bool giving;
    bool collecting;
    public int collectLimit = 15;
    public int moneyCount = 0;
    public Text moneyText;
    private bool isCollecting = false;
    private bool isCollecting1 = false;

    private bool isGiving = false;
    private bool isGiving1 = false; // Separate flag for the second table
    private bool isGiving2= false;
    public int moneyValue=1;

    

    private void Start()
    {
        collectLimit = PlayerPrefs.GetInt("collectvalue", collectLimit);
        moneyCount = PlayerPrefs.GetInt("money", moneyCount);
        moneyValue = PlayerPrefs.GetInt("moneyvalue", moneyValue);

        moneyText.text = moneyCount.ToString();
        UpgradeButtons = GameObject.FindGameObjectWithTag("UpgradeButtons");
        UnlockButtons = GameObject.FindGameObjectWithTag("UnlockButtons");
    }




    void GetPaper(List<GameObject> currentPaperList)
    {
        if (paperList.Count < collectLimit)
        {
            GameObject paper = Instantiate(paperPrefab, collectPoint);
            paperList.Add(paper);
            paper.transform.position = new Vector3(collectPoint.position.x, 0.5f + (float)paperList.Count / 10, collectPoint.position.z);

            if (collecting)
            {
                if (currentPaperList.Count > 0)
                {
                    if (currentPaperList == printerManager.paperList)
                        printerManager.RemoveLast();
                    else if (currentPaperList == printerManager1.paperList1)
                        printerManager1.RemoveLast1();
                    else if (currentPaperList == printerManager2.paperList2)
                        printerManager2.RemoveLast2();
                }
            }
        }
    }

    IEnumerator Collect(List<GameObject> currentPaperList)
    {
        if (isCollecting)
            yield break;

        isCollecting = true;

        if (collecting)
        {
            if (currentPaperList.Count > 0)
            {
                GetPaper(currentPaperList);
                yield return new WaitForSeconds(0.2f);
            }
        }

        isCollecting = false;
    }

    public void GivePaper(List<GameObject> currentMoneyList)
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);

            if (currentMoneyList == moneyManager.moneyList)
            {
                StartCoroutine(moneyManager.PrintMoney());
            }
            else if (currentMoneyList == moneyManager1.moneyList1)
            {
                StartCoroutine(moneyManager1.PrintMoney1());
            }
            else if (currentMoneyList == moneyManager2.moneyList2)
            {
                StartCoroutine(moneyManager2.PrintMoney2());
            }
        }
    }

    IEnumerator Give(List<GameObject> currentMoneyList)
    {
        if (currentMoneyList == moneyManager.moneyList)
        {
            if (isGiving)
                yield break;

            isGiving = true;

            if (giving)
            {
                if (paperList.Count > 0)
                {
                    GivePaper(currentMoneyList);
                    yield return new WaitForSeconds(0.2f);
                }
            }

            isGiving = false;
        }
        else if (currentMoneyList == moneyManager1.moneyList1)
        {
            if (isGiving1)
                yield break;

            isGiving1 = true;

            if (giving)
            {
                if (paperList.Count > 0)
                {
                    GivePaper(currentMoneyList);
                    yield return new WaitForSeconds(0.3f);
                }
            }

            isGiving1 = false;
        }
        else if (currentMoneyList == moneyManager2.moneyList2)
        {
            if (isGiving2)
                yield break;

            isGiving2 = true;

            if (giving)
            {
                if (paperList.Count > 0)
                {
                    GivePaper(currentMoneyList);
                    yield return new WaitForSeconds(0.3f);
                }
            }

            isGiving2 = false;
        }
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            collecting = true;
        }

        else if (other.gameObject.CompareTag("CollectArea1")) // Tag for the second printer's collect area
        {
            collecting = true;
        }

        else if (other.gameObject.CompareTag("CollectArea2")) // Tag for the second printer's collect area
        {
            collecting = true;
        }

        else if (other.gameObject.CompareTag("GiveArea"))
        {
            giving = true;

        }

        else if (other.gameObject.CompareTag("GiveArea1"))
        {
            giving = true;

        }

        else if (other.gameObject.CompareTag("GiveArea2"))
        {
            giving = true;

        }

        else if(other.gameObject.CompareTag("PrinterUpgrade"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UpgradeButtons.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        else if (other.gameObject.CompareTag("UnlockPrinter"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        else if (other.gameObject.CompareTag("UnlockWorker"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
              
                    UnlockButtons.transform.GetChild(1).gameObject.SetActive(true);

              
            }
            
        }

        else if (other.gameObject.CompareTag("UnlockPrinter1"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        else if (other.gameObject.CompareTag("UnlockWorker1"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {

                UnlockButtons.transform.GetChild(3).gameObject.SetActive(true);


            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            collecting = true;

            if (collecting)
            {
                StartCoroutine(Collect(printerManager.paperList));
            }
        }
        else if (other.gameObject.CompareTag("CollectArea1"))
        {
            collecting = true;

            if (collecting)
            {
                StartCoroutine(Collect(printerManager1.paperList1));
            }
        }
        else if (other.gameObject.CompareTag("CollectArea2"))
        {
            collecting = true;

            if (collecting)
            {
                StartCoroutine(Collect(printerManager2.paperList2));
            }
        }

        else if (other.gameObject.CompareTag("GiveArea"))
        {
            giving = true;
            if (giving == true)
            {
                StartCoroutine(Give(moneyManager.moneyList));
            }
        }

        else if (other.gameObject.CompareTag("GiveArea1"))
        {
            giving = true;
            if (giving == true)
            {
                StartCoroutine(Give(moneyManager1.moneyList1));
            }
        }

        else if (other.gameObject.CompareTag("GiveArea2"))
        {
            giving = true;
            if (giving == true)
            {
                StartCoroutine(Give(moneyManager2.moneyList2));
            }
        }

        else if (other.gameObject.CompareTag("MoneyArea"))
        {
            if(moneyManager.moneyList.Count > 0)
            {
                moneyCount+=moneyValue;
                moneyText.text = moneyCount.ToString();
                moneyManager.RemoveMoney();
                PlayerPrefs.SetInt("money", moneyCount);
                PlayerPrefs.Save();

            }
        }

        else if (other.gameObject.CompareTag("MoneyArea1"))
        {
            if (moneyManager1.moneyList1.Count > 0)
            {
                moneyCount += moneyValue * 2;
                moneyText.text = moneyCount.ToString();
                moneyManager1.RemoveMoney1();
                PlayerPrefs.SetInt("money", moneyCount);
                PlayerPrefs.Save();

            }
        }
        else if (other.gameObject.CompareTag("MoneyArea2"))
        {
            if (moneyManager2.moneyList2.Count > 0)
            {
                moneyCount += moneyValue * 3;
                moneyText.text = moneyCount.ToString();
                moneyManager2.RemoveMoney2();
                PlayerPrefs.SetInt("money", moneyCount);
                PlayerPrefs.Save();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            collecting = false;
            StopCoroutine(Collect(printerManager.paperList));
        }
        else if (other.gameObject.CompareTag("CollectArea1"))
        {
            collecting = false;
            // Stop the Collect coroutine for the second printer table
            StopCoroutine(Collect(printerManager1.paperList1));
        }
        else if (other.gameObject.CompareTag("CollectArea2"))
        {
            collecting = false;
            // Stop the Collect coroutine for the second printer table
            StopCoroutine(Collect(printerManager2.paperList2));
        }

        else if (other.gameObject.CompareTag("GiveArea"))
        {
            giving = false;
            moneyManager.StopCoroutine(moneyManager.PrintMoney());
        }

        else if (other.gameObject.CompareTag("GiveArea1"))
        {
            giving = false;
        }
        else if (other.gameObject.CompareTag("GiveArea2"))
        {
            giving = false;
        }


        else if (other.gameObject.CompareTag("PrinterUpgrade"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UpgradeButtons.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("UnlockPrinter"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        else if (other.gameObject.CompareTag("UnlockWorker"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("UnlockPrinter1"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        else if (other.gameObject.CompareTag("UnlockWorker1"))
        {
            for (int i = 0; i < UpgradeButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }


    private void OnDestroy()

    {
        PlayerPrefs.SetInt("collectvalue", collectLimit);
        PlayerPrefs.SetInt("money", moneyCount);
        PlayerPrefs.SetInt("moneyvalue", moneyValue);
        PlayerPrefs.Save();
    }

}


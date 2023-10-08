using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManager1 : MonoBehaviour
{




    public List<GameObject> paperList1 = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform stackPoint;


    bool working;
    int stackCount = 15;
    public int paperLimit = 15;

    private void Awake()
    {
        paperLimit = PlayerPrefs.GetInt("PaperLimit", paperLimit);

    }

    void Start()
    {
        StartCoroutine(PrintPaper());
        paperLimit = PlayerPrefs.GetInt("PaperLimit", paperLimit);

    }




    private void OnDestroy()

    {
        PlayerPrefs.SetInt("PaperLimit", paperLimit);
        PlayerPrefs.Save();

    }

    public void RemoveLast1()
    {
        if(paperList1.Count > 0)
        {
            Destroy(paperList1[paperList1.Count - 1]);
            paperList1.RemoveAt(paperList1.Count - 1);
        }
     
    }

    IEnumerator PrintPaper()
    {
        while(true)
        {
            float paperCount = paperList1.Count;
            int rowCount = (int)paperCount/15;
            if (working == true)
            {

                GameObject paper = Instantiate(paperPrefab);
                paperList1.Add(paper);
                paper.transform.position = new Vector3(stackPoint.position.x + (float)rowCount, (paperCount%stackCount)/8, stackPoint.position.z);
            }

     

            if(paperList1.Count+1 <= paperLimit)
            {
                working = true;
            }
            else if ( paperList1.Count+1 > paperLimit)
            {
                working = false;
            }
            yield return new WaitForSeconds(0.8f);

        }




    }

}


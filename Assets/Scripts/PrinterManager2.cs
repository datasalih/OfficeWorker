using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManager2 : MonoBehaviour
{




    public List<GameObject> paperList2 = new List<GameObject>();
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

    public void RemoveLast2()
    {
        if(paperList2.Count > 0)
        {
            Destroy(paperList2[paperList2.Count - 1]);
            paperList2.RemoveAt(paperList2.Count - 1);
        }
     
    }

    IEnumerator PrintPaper()
    {
        while(true)
        {
            float paperCount = paperList2.Count;
            int rowCount = (int)paperCount/15;
            if (working == true)
            {

                GameObject paper = Instantiate(paperPrefab);
                paperList2.Add(paper);
                paper.transform.position = new Vector3(stackPoint.position.x + (float)rowCount, (paperCount%stackCount)/8, stackPoint.position.z);
            }

     

            if(paperList2.Count+1 <= paperLimit)
            {
                working = true;
            }
            else if ( paperList2.Count+1 > paperLimit)
            {
                working = false;
            }
            yield return new WaitForSeconds(0.5f);

        }




    }

}


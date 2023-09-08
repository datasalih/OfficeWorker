using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManager : MonoBehaviour
{




    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform stackPoint;


    bool working;
    int stackCount = 15;
    public int paperLimit = 15;

    void Start()
    {
        StartCoroutine(PrintPaper());
        paperLimit = PlayerPrefs.GetInt("paperlimit", paperLimit);

    }




    private void OnDestroy()

    {
        PlayerPrefs.SetInt("paperlimit", paperLimit);
        PlayerPrefs.Save();

    }

    public void RemoveLast()
    {
        if(paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
     
    }

    IEnumerator PrintPaper()
    {
        while(true)
        {
            float paperCount = paperList.Count;
            int rowCount = (int)paperCount/15;
            if (working == true)
            {

                GameObject paper = Instantiate(paperPrefab);
                paperList.Add(paper);
                paper.transform.position = new Vector3(stackPoint.position.x + (float)rowCount, (paperCount%stackCount)/8, stackPoint.position.z);
            }

     

            if(paperList.Count+1 <= paperLimit)
            {
                working = true;
            }
            else if ( paperList.Count+1 > paperLimit)
            {
                working = false;
            }
            yield return new WaitForSeconds(1.2f);

        }




    }

}


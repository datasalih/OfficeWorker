using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public List<GameObject> moneyList = new List<GameObject>();
    public GameObject moneyPrefab;
    public Transform stackPoint;
    public CollectManager manager;

    bool working;
    int stackCount = 15;
    public int moneyLimit = 225;
    void Start()
    {

    }

    private void Update()
    {
        
    }

    public void RemoveMoney()
    {
        if (moneyList.Count > 0)
        {
            Destroy(moneyList[moneyList.Count - 1]);
            moneyList.RemoveAt(moneyList.Count - 1);
        }

    }

   
    

    public IEnumerator PrintMoney()
    {
        
            while (true)
            {
                float paperCount = moneyList.Count;
                int rowCount = (int)paperCount / 15;
                if (working == true)
                {

                    GameObject paper = Instantiate(moneyPrefab);
                    moneyList.Add(paper);
                    paper.transform.position = new Vector3(stackPoint.position.x + (float)rowCount, (paperCount % stackCount) / 6, stackPoint.position.z);
                if(paperCount >=75)
                {
                    paper.transform.position = new Vector3(stackPoint.position.x -5 + (float)rowCount, (paperCount % stackCount) / 6, stackPoint.position.z-0.9f);
                }
                if (paperCount >= 150)
                {
                    paper.transform.position = new Vector3(stackPoint.position.x - 10 + (float)rowCount, (paperCount % stackCount) / 6, stackPoint.position.z - 1.8f);
                }
                if (paperCount >= 225)
                {
                    paper.transform.position = new Vector3(stackPoint.position.x - 15 + (float)rowCount, (paperCount % stackCount) / 6, stackPoint.position.z - 2.7f);
                }


            }



                if (moneyList.Count +1  <= moneyLimit)
                {
                    working = true;
                }
                else if (moneyList.Count +1  > moneyLimit)
                {
                    working = false;
                }
            
                yield return new WaitForSeconds(6110f);

            }
        
    }
}

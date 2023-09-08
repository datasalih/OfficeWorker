using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager2 : MonoBehaviour
{
    public List<GameObject> moneyList2 = new List<GameObject>();
    public GameObject moneyPrefab;
    public Transform stackPoint;
    public CollectManager manager;

    bool working;
    int stackCount = 15;
    public int moneyLimit = 225;
    void Start()
    {

    }


    public void RemoveMoney2()
    {
        if (moneyList2.Count > 0)
        {
            Destroy(moneyList2[moneyList2.Count - 1]);
            moneyList2.RemoveAt(moneyList2.Count - 1);
        }

    }

   
    

    public IEnumerator PrintMoney2()
    {
        
            while (true)
            {
                float paperCount = moneyList2.Count;
                int rowCount = (int)paperCount / 15;
                if (working == true)
                {

                    GameObject paper = Instantiate(moneyPrefab);
                    moneyList2.Add(paper);
                    paper.transform.position = new Vector3(stackPoint.position.x + (float)rowCount, (paperCount % stackCount) / 8, stackPoint.position.z);
                if(paperCount >=75)
                {
                    paper.transform.position = new Vector3(stackPoint.position.x -5 + (float)rowCount, (paperCount % stackCount) / 8, stackPoint.position.z-0.9f);
                }
                if (paperCount >= 150)
                {
                    paper.transform.position = new Vector3(stackPoint.position.x - 10 + (float)rowCount, (paperCount % stackCount) / 8, stackPoint.position.z - 1.8f);
                }
                if (paperCount >= 225)
                {
                    paper.transform.position = new Vector3(stackPoint.position.x - 15 + (float)rowCount, (paperCount % stackCount) / 8, stackPoint.position.z - 2.7f);
                }


            }



                if (moneyList2.Count +1  <= moneyLimit)
                {
                    working = true;
                }
                else if (moneyList2.Count +1  > moneyLimit)
                {
                    working = false;
                }
            
                yield return new WaitForSeconds(6110f);

            }
        
    }
}

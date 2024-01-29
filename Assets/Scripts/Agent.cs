using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AI;
public class Agent : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    NavMeshAgent agent;
    public Animator anim;
    private bool isMoving = true;
    private GameObject printerTarget;
    private GameObject printerTarget1;
    private GameObject printerTarget2;

    private GameObject workerTarget;
    private GameObject workerTarget1;
    private GameObject workerTarget2;



    public AgentCollectManager agentManager;


    private void Awake()
    {
        printerTarget = GameObject.FindGameObjectWithTag("CollectArea");
        printerTarget1 = GameObject.FindGameObjectWithTag("CollectArea1");
        printerTarget2 = GameObject.FindGameObjectWithTag("CollectArea2");
        workerTarget = GameObject.FindGameObjectWithTag("MoneyArea");
        workerTarget1 = GameObject.FindGameObjectWithTag("MoneyArea1");
        workerTarget2 = GameObject.FindGameObjectWithTag("MoneyArea2");

    }

    private void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();

        if (upgradeManager.printerUnlocked)
        {
            agent.SetDestination(printerTarget1.transform.position);

        }

        if (upgradeManager.printer1Unlocked)
        {
            agent.SetDestination(printerTarget2.transform.position);
        }

        else
        {
            agent.SetDestination(printerTarget.transform.position);


        }


    }



    private void Update()
    {

        if (anim)
        {
            anim.SetBool("isMoving", isMoving);
        }

      

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isMoving = false;
            agent.speed = 0;
        }
        else if (other.gameObject.CompareTag("CollectArea1"))
        {
            isMoving = false;
            agent.speed = 0;
        }
        else if (other.gameObject.CompareTag("CollectArea2"))
        {
            isMoving = false;
            agent.speed = 0;
        }

        else if (other.gameObject.CompareTag("GiveArea"))
        {
            isMoving = false;
            agent.speed = 0;
        }
        else if (other.gameObject.CompareTag("GiveArea1"))
        {
            isMoving = false;
            agent.speed = 0;
        }
        else if (other.gameObject.CompareTag("GiveArea2"))
        {
            isMoving = false;
            agent.speed = 0;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            if (agentManager.paperList.Count >= 15)
            {
                if (upgradeManager.workerUnlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget1.transform.position);

                }

                 if (upgradeManager.worker1Unlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget2.transform.position);
                }
                else
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget.transform.position);
                }
            
            }

        }
    

        else if (other.gameObject.CompareTag("CollectArea1"))
        {
            if (agentManager.paperList.Count >= 15)
            {
                if (upgradeManager.workerUnlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget1.transform.position);

                }

                 if (upgradeManager.worker1Unlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget2.transform.position);
                }
                else
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget.transform.position);
                }

            }
        }
       else if (other.gameObject.CompareTag("CollectArea2"))
        {
            if (agentManager.paperList.Count >= 15)
            {
                if (upgradeManager.workerUnlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget1.transform.position);

                }

                 if (upgradeManager.worker1Unlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget2.transform.position);
                }
                else
                {
                    agent.speed = 7f;
                    agent.SetDestination(workerTarget.transform.position);
                }

            }
        }


        else if (other.gameObject.CompareTag("GiveArea"))
        {
            if (agentManager.paperList.Count == 0)
            {
                if (upgradeManager.printerUnlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget1.transform.position);

                }

                 if (upgradeManager.printer1Unlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget2.transform.position);
                }
                else
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget.transform.position);


                }
            }
        }
        else if (other.gameObject.CompareTag("GiveArea1"))
        {
            if (agentManager.paperList.Count == 0)
            {
                if (upgradeManager.printerUnlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget1.transform.position);

                }

                 if (upgradeManager.printer1Unlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget2.transform.position);
                }
                else
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget.transform.position);


                }
            }
        }
        else if (other.gameObject.CompareTag("GiveArea2"))
        {
            if (agentManager.paperList.Count == 0)
            {
                if (upgradeManager.printerUnlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget1.transform.position);

                }

                 if (upgradeManager.printer1Unlocked)
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget2.transform.position);
                }
                else
                {
                    agent.speed = 7f;
                    agent.SetDestination(printerTarget.transform.position);


                }
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isMoving = true;
            agent.speed = 14f;
        }
         if (other.gameObject.CompareTag("CollectArea1"))
        {
            isMoving = true;
            agent.speed = 14f;
        }
         if (other.gameObject.CompareTag("CollectArea2"))
        {
            isMoving = true;
            agent.speed = 14f;
        }

         if (other.gameObject.CompareTag("GiveArea"))
        {
            isMoving = true;
            agent.speed = 7f;
        }
         if (other.gameObject.CompareTag("GiveArea1"))
        {
            isMoving = true;
            agent.speed = 7f;
        }
         if (other.gameObject.CompareTag("GiveArea2"))
        {
            isMoving = true;
            agent.speed = 7f;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace TrafficRacer
{
    /// <summary>
    /// Script which manages spawning, activation and deactivation of enemies
    /// </summary>
    public class MoneyManager
    {
        private List<GameObject> deactiveMoneyList;                 //list to store deactive enemy gameobjects
        private Vector3[] moneySpawnPos = new Vector3[3];           //array of possible spawn position
        private GameObject moneyHolder;                             //parent object for all enemy objects
        private float moveSpeed;                                    //moving speed

        public MoneyManager(Vector3 spawnPos, float moveSpeed)      //constructor of script
        {       
            this.moveSpeed = moveSpeed;                             //set the speed
            deactiveMoneyList = new List<GameObject>();             //initialize list

            moneySpawnPos[0] = spawnPos - Vector3.right * 3;        //set 0 element of spawn position
            moneySpawnPos[1] = spawnPos;                            //set 1 element of spawn position
            moneySpawnPos[2] = spawnPos + Vector3.right * 3;        //set 2 element of spawn position
            //create gameobject of name EnemyHolder as assign to enemyHolder
            moneyHolder = new GameObject("MoneyHolder");           
        }

        public void SpawnMoney(GameObject[] vehiclePrefabs)       //method to spawn enemies
        {
            for (int i = 0; i < vehiclePrefabs.Length; i++)         //loop through all the vehicles in the list
            {                                                       //spawn the enemy
                GameObject money = Object.Instantiate(vehiclePrefabs[i], moneySpawnPos[1], Quaternion.identity);
                money.SetActive(false);                             //deactivate the enemy
                money.transform.SetParent(moneyHolder.transform);   //set its parent
                money.name = "Money";                               //set the name
                money.AddComponent<MoneyController>();              //attach EnemyController componenet to it
                money.GetComponent<MoneyController>().SetDefault(moveSpeed, this);  
                deactiveMoneyList.Add(money);                       //add to deactiveEnemyList
            }
        }

        public void ActivateMoney()                                 //method to activate the enemy
        {   
            if (deactiveMoneyList.Count > 0)                        //check if the deactiveEnemyList have elements
            {                                                       //if yes then randomly get anly one of them
                GameObject money = deactiveMoneyList[Random.Range(0, deactiveMoneyList.Count)];
                deactiveMoneyList.Remove(money);                    //remove the element from the list
                money.transform.position = moneySpawnPos[Random.Range(0, moneySpawnPos.Length)];    //set spawn position
                money.SetActive(true);                              //activate the enemy
            }
        }

        public void DeactivateMoney(GameObject money)               //method to deactivate the enemy
        {
            money.SetActive(false);                                 //deactivate the enemy
            deactiveMoneyList.Add(money);                           //add to deactiveEnemyList
        }
    }
}
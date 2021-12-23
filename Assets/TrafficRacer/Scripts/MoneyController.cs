using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficRacer
{
    /// <summary>
    /// Script which controls the enemy
    /// </summary>
    public class MoneyController : MonoBehaviour
    {
        private float moveSpeed;                        //variable to store speed
        MoneyManager moneyManager;                      //variable to store EnemyManager
        public void SetDefault(float speed, MoneyManager moneyManager)  //set speed and EnemyManager
        {
            moveSpeed = speed;
            this.moneyManager = moneyManager;
        }

        private void Update()
        {
            if (GameManager.singeton.gameStatus == GameStatus.PLAYING)  //if gameStatus is PLAYING
            {
                transform.Translate(-transform.forward * moveSpeed * 0.8f * Time.deltaTime);    //move the gameobject

                if (transform.position.z <= -10f)                       //if object z is less than -10
                {
                    moneyManager.DeactivateMoney(gameObject);           //deactvate the object
                }
            }
        }
    }
}
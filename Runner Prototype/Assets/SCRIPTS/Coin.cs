﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D Player) {
        if(Player){
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}

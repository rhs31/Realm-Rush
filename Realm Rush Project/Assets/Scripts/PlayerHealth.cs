﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = health.ToString();
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        healthText.text = health.ToString();
    }
}

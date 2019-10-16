using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int Health = 10;
    [SerializeField] int healthDecrease = 1;

    private void OnTriggerEnter(Collider other)
    {
        Health = Health - healthDecrease;
        print(Health);
    }
}

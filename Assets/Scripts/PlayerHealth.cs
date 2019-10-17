using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int Health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] private Text healthText;
    [SerializeField] private AudioClip reachedBaseSound;
    

    private void Start()
    {
        healthText.text = "HP: " + Health.ToString() + "/10";
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(reachedBaseSound);
        Health = Health - healthDecrease;
        healthText.text = "HP: " + Health.ToString()+ "/10";
    }
}

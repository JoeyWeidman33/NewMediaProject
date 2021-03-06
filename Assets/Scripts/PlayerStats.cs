﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    //PlayerStats will hold any variables related to the player happiness or any other modifier.

    [SerializeField] private float playerHappiness;

    //The gameobject Followers, used to calculate the max value for the happiness slider
    public GameObject FollowersList;

    //Under canvas HappinessSlider
    public Slider HappinessSlider;

    public GameObject SpawnArea;

    public Sprite NeutralSprite;
    public Sprite HappySprite;

    public SpriteRenderer SpriteRenderer;

	// Use this for initialization
	void Start () {
        //happinessSlider = GetComponent<Slider>();
        ResetPosition();
        playerHappiness = 0;
        HappinessSlider.maxValue = FollowersList.transform.childCount;
        SpriteRenderer = GetComponent<SpriteRenderer>();

	}

    public void ResetPosition()
    {
        gameObject.transform.position = SpawnArea.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Updates the HappinessSlider's value based on the current playerHappiness
        HappinessSlider.value = playerHappiness;

        if(playerHappiness == 4)
        {
            SpriteRenderer.sprite = NeutralSprite;
        }
        if(playerHappiness == 6)
        {
            SpriteRenderer.sprite = HappySprite;
        }
	}

    //Public function called in the Follower OnCollisionEnter to increment the amount of happiness
    public void IncrementHappiness(int i_happiness)
    {
        playerHappiness += i_happiness;
    }
}

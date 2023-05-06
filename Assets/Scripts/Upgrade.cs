using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Upgrade
{
    public string id;
    public string prereqId;
    public string buttonText;

    public string followerCostStr;
    public string viewRequirementStr;
    public float attentionCost;

    [HideInInspector] public double followerCost = 0;
    [HideInInspector] public double viewRequirement = 0;



    [TextArea]
    public string header;
    [TextArea]
    public string description;
    [TextArea] 
    public string optionalCostText;

    public double clickMultiplier;
    public float attentionFloor;
    public float attentionLossMultiplier;
    public float attentionLossDelay;
    public double maxAttention;
    public int maxOfflineTime;
    public float viewMultiplier;
    public int eventChance;
    public int eventSuccessChance;
    public float eventGainMultiplier;
    public float eventLossMultiplier;
    public float idleFollowerMultiplier;

    public void Initialize()
    {
        if(followerCostStr != "")
            followerCost = CalcUtils.StringToNumber(followerCostStr);

        if(viewRequirementStr != "")
            viewRequirement = CalcUtils.StringToNumber(viewRequirementStr);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Upgrade
{
    public string id;
    public string prereqId;
    public double followerCost;
    public float attentionCost;
    public double viewRequirement;
    public string buttonText;

    public double clickMultiplier;
    public float attentionFloor;
    public float attentionLossMultiplier;
    public float attentionLossDelay;
    public float maxAttention;
    public int maxOfflineTime;
}
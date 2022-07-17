using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour
{
    public Text temps;
    private int minute;
    private int seconde;
    private float tempsTotal;
    void Update()
    {
        tempsTotal += Time.deltaTime;
        while (tempsTotal >= 60)
        {
            tempsTotal -= 60;
            minute++;
        }
        seconde = (int)tempsTotal;
        temps.text = minute + "m " + seconde + "s";
    }
}
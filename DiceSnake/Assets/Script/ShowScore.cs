using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text UI;
    public void SetScore(int score)
    {
        UI.text = score.ToString();
    }
}
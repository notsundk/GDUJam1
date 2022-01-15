using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_DayCounter : MonoBehaviour
{
    public TextMeshProUGUI tm;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        tm.text = "Day " + GameManager.Instance.day.ToString();
    }
}

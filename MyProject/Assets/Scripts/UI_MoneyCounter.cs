using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_MoneyCounter : MonoBehaviour
{
    public TextMeshProUGUI tm;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = player.money.ToString();
    }
}

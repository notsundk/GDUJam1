using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject Ground;

    [SerializeField] private int columnCount;
    [SerializeField] private int rowCount;

    [SerializeField] private float groundSizeX;
    [SerializeField] private float groundSizeY;


    void Start()
    {
        int x = 0;
        for(int i = 0; i < columnCount; i++)
        {
            for(int j = 0; j < rowCount; j++)
            {
                GameObject temp = Instantiate(Ground);
                temp.transform.parent = this.transform;
                temp.transform.position = new Vector3(i * groundSizeX - (groundSizeX * columnCount/2), j * groundSizeY - (groundSizeY * rowCount / 2), 0);
                temp.GetComponent<Ground>().id = x;
                x++;
            }
        }
    }

    void Update()
    {
        
    }
}

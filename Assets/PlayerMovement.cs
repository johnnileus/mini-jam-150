using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerMovement : MonoBehaviour
{

    [SerializeField] private int step;
    [SerializeField] private int sizeX;
    [SerializeField] private int sizeY;

    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = Vector2.zero;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(pos.y < sizeY)
            {
                transform.position += new Vector3(step, 0f, 0f);
                pos.y++;
            }
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if (pos.y > -sizeY)
            {
                transform.position += new Vector3(-step, 0f, 0f);
                pos.y--;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (pos.x < sizeX)
            {
                transform.position += new Vector3(0f, 0f, step);
                pos.x++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (pos.x > -sizeX)
            {
                transform.position += new Vector3(0f, 0f, -step);
                pos.x--;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 startPos;
    private float repeatwidth;

    void Start()
    {
        startPos = transform.position;
        repeatwidth = GetComponent<BoxCollider2D>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatwidth)
        {
            transform.position = startPos;
        }
    }
}

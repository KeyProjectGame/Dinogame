﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    private PlayerControl playerControlScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player_1").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlScript.level2 == true)
        {
            gameObject.transform.position = new Vector3 (14.3f, -5, -89.57f);
        }
    }
}

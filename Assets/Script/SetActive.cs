using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{

    public GameObject activeObject;
    public GameObject activeObject_2;
    public bool activeateme;
    private PlayerControl playerControlScript;
    // Update is called once per frame

    void Start()
    {
        playerControlScript = GameObject.Find("Player_1").GetComponent<PlayerControl>();
    }

    void Update()
    {
        if (playerControlScript.level2 == true)
        {
            activeObject.SetActive(true);
            activeObject_2.SetActive(true);
        }
    }

}

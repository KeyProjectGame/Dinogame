using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_left : MonoBehaviour
{
    private float leftBound = -50f;
    [SerializeField] float speed = 10;
    private PlayerControl playerControlScript;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameMananager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
       {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
       }
        DestroyObject();
    }

    void DestroyObject()
    {
        if (transform.position.x < -24f)
        {
            Destroy(gameObject);
        }
    }
}

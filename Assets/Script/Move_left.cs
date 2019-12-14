using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_left : MonoBehaviour
{
    private float leftBound = -50f;
    [SerializeField] float speed = 10;
    private PlayerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void DestroyObject()
    {
        if (transform.position.x < -24f)
        {
            Destroy(gameObject);
        }
    }
}

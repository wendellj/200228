using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set In Inspector")]
    public GameObject ball;
    public float spawnTime = 1.0f;

    public void Start()
    {
        InvokeRepeating("CreateBall", spawnTime, spawnTime);
    }

    // Update is called once per frame
    public void Update()
    {
        //SpawnBall();
    }

    public void CreateBall()
    {
        // Grab the ball from the Unity file
        var newBall = GameObject.Instantiate(ball);
        newBall.tag = "BallToSpawn";
        var x = Random.Range(-2.0f, 2.0f);
        var y = Random.Range(5.0f, 10.0f);
        var z = Random.Range(-2.0f, 2.0f);
        var ballPosition = transform.position;
        ballPosition.y += newBall.transform.localScale.y + 1.0f;
        var r = newBall.GetComponent<Rigidbody>();
        r.position = ballPosition;
        //Debug.Log($"X:{x}, Y:{y}, Z:{z}");
        //QuestDebug.Instance.Log($"Created ball at: X:{ballPosition.x}, Y:{ballPosition.y}, Z:{ballPosition.z}, force: X:{x}, Y:{y}, Z:{z}");
        r.AddForce(x,y,z, ForceMode.VelocityChange);

        //Add this ball to the item list
        GameManager.instance.AddItemToManager(newBall);
    }
}

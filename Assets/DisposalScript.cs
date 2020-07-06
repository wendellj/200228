using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DisposalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        QuestDebug.Instance.Log($"Trigger destroying object {other.tag}, {tag}");
        if (other.CompareTag("BallToSpawn") && CompareTag("Disposal"))
        {
            Debug.Log("destroying object");
            GameManager.instance.RemoveItemFromManager(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collider other)
    {
        QuestDebug.Instance.Log($"Collision destroying object {other.tag}, {tag}");
        if (other.CompareTag("BallToSpawn") && CompareTag("Disposal"))
        {
            Debug.Log("destroying object");
            GameManager.instance.RemoveItemFromManager(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}

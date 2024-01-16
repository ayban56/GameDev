using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFishMovement : MonoBehaviour
{
    public float speed = 3f;
    private Transform playerTransform;

    void Start()
{
    GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
    if (playerObject != null)
    {
        playerTransform = playerObject.transform;
    }
    else
    {
        Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
    }
}

void Update()
{
    if (playerTransform != null)
    {
           transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    else
    {
        Debug.Log("Player not found.");
    }
}

}

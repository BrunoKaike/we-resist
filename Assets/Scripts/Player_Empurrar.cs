using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Empurrar : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;

    GameObject box;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right*transform.localScale.x,distance,boxMask);
        
        if (hit.collider != null && Input.GetKey(KeyCode.C))
        {
            box = hit.collider.gameObject;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}

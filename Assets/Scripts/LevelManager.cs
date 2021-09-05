using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Recriar o personagem
    public void RespawnPlayer()
    {
        Debug.Log("Respawn Player");
        player.transform.position = currentCheckpoint.transform.position;
        player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
}

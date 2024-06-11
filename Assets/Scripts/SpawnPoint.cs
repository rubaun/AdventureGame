using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public BoxCollider2D box;
    public Vector3 posSpawn;
    public GameObject player;
    public Player playerScript;
    public GameObject preFab;
    public int vidasPlayer;
    public bool instantiate;

    // Start is called before the first frame update
    void Start()
    {
        instantiate = true;

        posSpawn =  transform.position;

        if(player == null)
        {
            Instantiate(preFab,
                        new Vector3(posSpawn.x,posSpawn.y,posSpawn.z), 
                        Quaternion.identity);
        }
        
        player = GameObject.FindWithTag("Player");
        
        playerScript = player.GetComponent<Player>();

        vidasPlayer = playerScript.VidasDoPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null && instantiate && vidasPlayer >= 1)
        {
           Instantiate(preFab,
                        new Vector3(posSpawn.x,posSpawn.y,posSpawn.z), 
                        Quaternion.identity);
           player = GameObject.FindWithTag("Player");
           playerScript = player.GetComponent<Player>();
           vidasPlayer--;
           playerScript.AtualizaVidas(vidasPlayer);
        }

        if(vidasPlayer <= 1)
        {
            instantiate = false;
            vidasPlayer = 0;
        }

    }

    public int VidasDoPlayerAtual()
    {
        return vidasPlayer;
    }
}

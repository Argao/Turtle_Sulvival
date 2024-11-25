using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public GameManager gameManager;
    public GameObject prefab;
    public float spawnRate = 2f;
    public float minHeight = -1;
    public float maxHeight = 1;
    
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    
    

    private void Spawn()
    {
        GameObject obstacles = Instantiate(prefab , transform.position, Quaternion.identity);
        
        setDifficulty();
        
        //randomize the height of the obstacles
        obstacles.transform.position +=  Vector3.up * UnityEngine.Random.Range(minHeight, maxHeight); 
        
        //randomize the sprite of the obstacles
        Transform top = obstacles.transform.Find("Top");
        Transform bottom = obstacles.transform.Find("Bottom");

        top.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
        bottom.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
        
        
    }

    private void setDifficulty()
    {
        if (gameManager.score  % 10 == 0 && gameManager.score != 0 )
        {
            if (maxHeight < 3.5f)
            {
                maxHeight += 0.5f;
                minHeight -=  0.5f;
            }

        }
        else
        {
            maxHeight = 1;
            minHeight = -1;
        }


    }

}

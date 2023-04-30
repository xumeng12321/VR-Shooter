using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject brickPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(brickPrefab);

        for (int y = 0; y < 5; y++){
            for (int x = 0; x < 5; x++){
                Vector3 position = new Vector3(x * 2, y, 0);
                Instantiate(brickPrefab, position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

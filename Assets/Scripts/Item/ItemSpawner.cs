using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateItem(Vector3 pos, int index){
        if((index % 3) == 0){
            GameObject item = Instantiate(items[RandomIndex()], pos, Quaternion.identity);
        }
    }

    int RandomIndex(){
        return Random.Range(0, 5);
    }

}

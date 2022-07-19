using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;



public class RandomSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefabInstance;   

    //private GameObject[] avatars=new GameObject[10];
    //private Dictionary<string, string> avatars = new Dictionary<string, string>();
    [SerializeField] private int numOfAvatars = 1;
    //[SerializeField] private List<string> names;    
    private GameObject res, resName;
    


    void Start()
    {
        //int randomIndex = Random.Range(0, avatars.Length);
        for (int c = 0; c < numOfAvatars; c++)
        {
            
            spawnIt(prefabInstance);

        }



    }

    void spawnIt(GameObject obj, bool showIndicator = false)
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 21), 1, Random.Range(-20, 21));
        obj = Instantiate(obj, randomSpawnPosition, Quaternion.identity);
        resName=obj.transform.Find("avNameCanvas").gameObject;
        resName.GetComponent<TextMeshProUGUI>().enabled = true;
        //resName.GetComponent<TextMeshProUGUI>().text = "0";
        //resName.GetComponent<TextMeshProUGUI>().enabled = true;
        if (showIndicator)
        {
            res = obj.transform.Find("indicator").gameObject;
            res.GetComponent<MeshRenderer>().enabled = true;
        }


        /*if (obj.CompareTag("indicator"))
        {


        }*/
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            spawnIt(prefabInstance, true);
        }

    }
}


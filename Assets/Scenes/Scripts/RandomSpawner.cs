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
    [SerializeField] private int numOfAvatars = 10;
    //[SerializeField] private List<string> names;    
    private GameObject res, resName;



    void Start()
    {
        Globals.userReference = new List<string>();
        //int randomIndex = Random.Range(0, avatars.Length);
        for (int c = 0; c < numOfAvatars; c++)
        {

            spawnIt(prefabInstance, c);

        }
        foreach (string reference in Globals.userReference)
        {
            //Debug.Log(reference);
        }


    }

    void spawnIt(GameObject obj, int c, bool showIndicator = false)
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 21), 1, Random.Range(-20, 21));
        obj = Instantiate(obj, randomSpawnPosition, Quaternion.identity);
        obj.name = System.Guid.NewGuid().ToString();
        Globals.userReference.Add(obj.name);
        resName = obj.transform.Find("avNameCanvas/avName").gameObject;
        resName.GetComponent<TextMeshProUGUI>().text = Globals.groupUsers[c].ToString();
        //obj.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);



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
            spawnIt(prefabInstance, 0, true);
            Globals.numSelected += 1;
        }

    }
}


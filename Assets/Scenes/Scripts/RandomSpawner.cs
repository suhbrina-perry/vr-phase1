using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;



public class RandomSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefabInstance;


    [SerializeField] private int numOfAvatars = 10;

    private GameObject res, resName;
    [SerializeField]
    private TextMeshProUGUI txtUserEntryList;
    

    void Start()
    {
        Globals.userReference = new List<string>();
        Globals.users = new Dictionary<string, string>();

        for (int c = 0; c < numOfAvatars; c++)
        {

            spawnIt(prefabInstance, c);

        }
        var entries = Globals.users.ToDictionary(entry => entry.Key, entry => entry.Value);
        // Shuffling Dictionary
        System.Random rand = new System.Random(3);
        entries = entries.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);
        
        for (var i = 1; i <= entries.Count-Random.Range(-1,7); i++)
        {
            KeyValuePair<string, string> user = entries.ElementAt(i);
            txtUserEntryList.text += user.Value+"\n";
        }
        /*foreach (KeyValuePair<string, string> user in entries)
        {

            txtUserEntryList.text += user.Value + "\n";


        }*/

    }

    void spawnIt(GameObject obj, int c, bool showIndicator = false)
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 21), 1, Random.Range(-20, 21));
        obj = Instantiate(obj, randomSpawnPosition, Quaternion.identity);
        obj.name = System.Guid.NewGuid().ToString();
        Globals.userReference.Add(obj.name);
        Globals.users.Add(obj.name, Globals.groupUsers[c].ToString());

        resName = obj.transform.Find("avNameCanvas/avName").gameObject;
        resName.GetComponent<TextMeshProUGUI>().text = Globals.groupUsers[c].ToString();




        if (showIndicator)
        {
            res = obj.transform.Find("indicator").gameObject;
            res.GetComponent<MeshRenderer>().enabled = true;


        }

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


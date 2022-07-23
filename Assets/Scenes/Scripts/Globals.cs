using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class Globals : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI selectedCounter;
    [SerializeField]
    private Button groupAddButton;
    [SerializeField] private GameObject modalWindow;
    [SerializeField] private GameObject modalWindowEntries;
    private Renderer material;
    public static int numSelected = 0;
    public static int groupSize = 2;
    private int c = 0;
    public static Dictionary<string, string> selectedUsers;
    public static List<string> userReference;
    public static Dictionary<string, string> users;


    public static string[] groupUsers = new string[] {
                "Logan Hopkins",
                "Milton Dennis",
                "Ilene Ryan",
                "Dino Randolph",
                "Sally Nichols",
                "Allison Mcguire",
                "Reinaldo Esparza",
                "Irma Davila",
                "Lily Burke",
                "Colin Floyd"
    };


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(updateIndicators());
        Globals.selectedUsers = new Dictionary<string, string>();        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(selectedUsers.Count);
        selectedCounter.text = numSelected.ToString();
        if (numSelected >= groupSize)
        {
            if(!Interactable.isAccepted) groupAddButton.gameObject.SetActive(true);

        }
        else
        {
            groupAddButton.gameObject.SetActive(false);
        }

    }

    public IEnumerator updateIndicators()
    {

        while (true)
        {
            /* Debug.Log("inside updateIndicators");
             Debug.Log(Interactable.isAccepted);*/
            yield return new WaitForSeconds(0);
            if (Interactable.isAccepted)
            {
                groupAddButton.gameObject.SetActive(false);
                foreach (KeyValuePair<string, string> user in Globals.selectedUsers)
                {

                    var res = GameObject.Find(user.Key + "/indicator");
                    var isEnabled = res.GetComponent<MeshRenderer>().enabled;
                    material = res.GetComponent<Renderer>();

                    yield return new WaitForSeconds(5);
                    //Debug.Log("sdsd");
                    if (isEnabled)
                    {
                        material.material.SetColor("_Color" +
                             "", Color.green);

                    }
                    c++;




                }
            }
        }


    }


}

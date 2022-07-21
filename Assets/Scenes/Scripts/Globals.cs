using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Globals : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI selectedCounter;
    [SerializeField]
    private Button groupAddButton;
    [SerializeField] private TextMeshProUGUI userListBox;
    [SerializeField] private GameObject modalWindow;


    public static int numSelected = 0;
    public static int groupSize=2;
    public static List<string> selectedUsers;
    public static List<string> userReference; 
    
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
        Globals.selectedUsers = new List<string>();
        //modalWindow.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        /*if(numSelected>0)
        {
            userListBox.text = "";
            foreach (string user in selectedUsers)
            {
                userListBox.text += user + " ";
            }
        }*/

        //Debug.Log(selectedUsers.Count);
        selectedCounter.text = numSelected.ToString();
        if (numSelected>=groupSize)
        {
            groupAddButton.gameObject.SetActive(true);
            
        } else
        {
            groupAddButton.gameObject.SetActive(false);
        }
    }
}

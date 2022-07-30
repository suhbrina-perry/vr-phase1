using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;
using System.Linq;

public class Interactable : MonoBehaviour
{


    [SerializeField] private GameObject prefabInstance;
    [SerializeField] private GameObject btnCreateGroupInstance;
    [SerializeField] private GameObject modalWindow;
    [SerializeField] private GameObject modalWindowEntries;
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject btnRestart;

    public static bool isAccepted = false;
    private GameObject resName;
    
    private Renderer material;
    private int c = 0;
    [SerializeField]
    private TextMeshProUGUI txtUserList;
    [SerializeField]
    private TextMeshProUGUI txtUserEntryList;

    Color orange = new Color(1.0f, 0.64f, 0.0f);

    public void Start()
    {


        if(panel1) panel1.SetActive(true);
        if(panel2) panel2.SetActive(false);
        //modalWindow.SetActive(false);

    }

    public void Selected()
    {

        var res = prefabInstance.transform.Find("indicator").gameObject;
        var isEnabled = res.GetComponent<MeshRenderer>().enabled;
        var material = res.GetComponent<Renderer>();

        var name = prefabInstance.gameObject.name;
        var userName = Globals.users[name];


        if (isEnabled)
        {
            res.GetComponent<MeshRenderer>().enabled = false;
            Globals.numSelected -= 1;
            Globals.selectedUsers.Remove(userName);
        }
        else
        {
            res.GetComponent<MeshRenderer>().enabled = true;
            Globals.numSelected += 1;
            if (!Globals.selectedUsers.ContainsKey(name))
            {


                Globals.selectedUsers.Add(name, userName);
            }


        }


        Globals.groupSize = Globals.numSelected;
    }

    

    public void ClickButtonCreateGroup()
    {

        modalWindow.SetActive(true);
        txtUserList.text = "";
        foreach (KeyValuePair<string, string> user in Globals.selectedUsers)
        {

            txtUserList.text += user.Value + "\n";


        }

    }

    public void clickedDecline()
    {
        modalWindow.SetActive(false);
        isAccepted = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void clickedAccept()
    {
        isAccepted = true;
        
        foreach (KeyValuePair<string, string> user in Globals.selectedUsers)
        {
            //Debug.Log("oops " + user.Value);
            if (!Globals.selectedEntries.ContainsKey(user.Key))
            {
                isAccepted = false;
                //Debug.Log("oops " + user.Value);
                
            }


        }
        
        if(panel1) panel1.SetActive(false);
        if(panel2) panel2.SetActive(true);

        var objects = GameObject.FindGameObjectsWithTag("Avatar");

       

        if (panel2)
        {
            if(Globals.check==0)
            {
                foreach (var obj in objects)
                {
                    var res = obj.transform.Find("indicator").gameObject;
                    var isEnabled = res.GetComponent<MeshRenderer>().enabled;
                    var material = res.GetComponent<Renderer>();
                    res.GetComponent<MeshRenderer>().enabled = false;

                }

               
            }
            

            Globals.entries.Clear();
            Globals.selectedEntries.Clear();
            Globals.selectedUsers.Clear();
            Globals.entries = Globals.users.ToDictionary(entry => entry.Key, entry => entry.Value);
            Globals.numSelected = 0;
            // Shuffling Dictionary
            System.Random rand = new System.Random();
            Globals.entries = Globals.entries.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);

            for (var i = 1; i <= Random.Range(2, 4); i++)
            {
                KeyValuePair<string, string> user = Globals.entries.ElementAt(i - 1);
                Globals.selectedEntries.Add(user.Key, user.Value);
                txtUserEntryList.text += user.Value + "\n";
            }
            if(Globals.check>0)
            {
                foreach (var obj in objects)
                {
                    var res = obj.transform.Find("indicator").gameObject;
                    var isEnabled = res.GetComponent<MeshRenderer>().enabled;
                    var material = res.GetComponent<Renderer>();
                    res.GetComponent<MeshRenderer>().enabled = false;
                    if (!isEnabled)
                    {
                        obj.SetActive(false);
                        Debug.Log(isEnabled+" not enabled");
                    }


                }
            }
            
            isAccepted = false;
            Debug.Log(Globals.check);
            Globals.check++;

        }
        

            
        



        //Debug.Log(panel2);
        //res.SetActive(true);
        modalWindow.SetActive(false);

        /*foreach (KeyValuePair<string, string> user in Globals.selectedUsers)
        {            
            var res = GameObject.Find(user.Key + "/indicator");
            var isEnabled = res.GetComponent<MeshRenderer>().enabled;
            material = res.GetComponent<Renderer>();

            if (isEnabled)
            {
                material.material.SetColor("_Color" +
                     "", Color.green);               

            }
        }*/


    }

    public void clickedOK()
    {
        modalWindowEntries.SetActive(false);
    }

    









}

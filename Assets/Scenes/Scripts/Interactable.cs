using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{


    [SerializeField] private GameObject prefabInstance;
    [SerializeField] private GameObject btnCreateGroupInstance;
    [SerializeField] private GameObject modalWindow;
    [SerializeField] private GameObject modalWindowEntries;
    [SerializeField] private GameObject btnRestart;

    public static bool isAccepted = false;
    private GameObject resName;
    private Renderer material;
    private int c = 0;
    [SerializeField]
    private TextMeshProUGUI txtUserList;
    
    Color orange = new Color(1.0f, 0.64f, 0.0f);

    public void Start()
    {
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
                Debug.Log("oops " + user.Value);
                
            }


        }
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

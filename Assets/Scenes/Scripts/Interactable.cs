using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Interactable : MonoBehaviour
{


    [SerializeField] private GameObject prefabInstance;
    [SerializeField] private GameObject btnCreateGroupInstance;
    [SerializeField] private GameObject modalWindow;

    private GameObject resName;
    private Renderer material;
    Color orange = new Color(1.0f, 0.64f, 0.0f);
    // Start is called before the first frame update
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
        //resName = res.transform.Find("avNameCanvas/avName").gameObject;
        //resName.GetComponent<TextMeshProUGUI>().text = Globals.groupUsers[c].ToString();
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
            if (!Globals.selectedUsers.Contains(name))
            {

                //Debug.Log(userName);
                Globals.selectedUsers.Add(userName);
            }

            //Debug.Log(Globals.selectedUsers.Count);
            /*material.material.SetColor("_Color" +
                "", Color.yellow);*/
        }

        //Globals.selectedUsers[Globals.selectedUsers.Length] = "SHE IS CRAZY";

    }

    public void ClickButtonCreateGroup()
    {

        modalWindow.SetActive(true);

        

        
        /*foreach (string reference in Globals.userReference)
        {
            var res = GameObject.Find(reference + "/indicator");
            var isEnabled = res.GetComponent<MeshRenderer>().enabled;
            material = res.GetComponent<Renderer>();

            if (isEnabled)
            {
                material.material.SetColor("_Color" +
                     "", orange);
            }
        }*/
        //Debug.Log(Globals.selectedUsers[0]);
        //var selected=res.GetComponents<MeshRenderer>().
        //Debug.Log("I CLICKED THE BUTTON");

    }
 
    public void clickedDecline()
    {
        modalWindow.SetActive(false);
    }

    public void clickedAccept()
    {
        modalWindow.SetActive(false);
        //Debug.Log(Globals.selectedUsers.Count);


        foreach (string user in Globals.selectedUsers)
        {
            Debug.Log(user);
        }

        /*for (int i = 0; i < Globals.selectedUsers.Count-1; i++)
        {
            var res = GameObject.Find(Globals.selectedUsers[i].ToString() + "/indicator");
            var isEnabled = res.GetComponent<MeshRenderer>().enabled;
            material = res.GetComponent<Renderer>();
            Debug.Log(Globals.selectedUsers[i].ToString());
            if (isEnabled)
            {
                material.material.SetColor("_Color" +
                     "", Color.green);
                
            }
        }*/
        /*for (int i = 0; i < Globals.userReference.Count; i++)
        {

            *//*for (int cc = 0; cc < 10000; cc++)
            {
                Debug.Log("waiting");
            }*//*
            var res = GameObject.Find(Globals.userReference[i] + "/indicator");
            var isEnabled = res.GetComponent<MeshRenderer>().enabled;
            material = res.GetComponent<Renderer>();

            if (isEnabled)
            {
                material.material.SetColor("_Color" +
                     "", Color.green);
                continue;
            }
        }*/


        


        /*foreach (string user in Globals.selectedUsers)
        {
            D
        }*/
    }





}

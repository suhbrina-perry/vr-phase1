using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    

    [SerializeField] private GameObject prefabInstance;    
    
    
    // Start is called before the first frame update
    public void Selected()
    {
        
        var res = prefabInstance.transform.Find("indicator").gameObject;
        var isEnabled = res.GetComponent<MeshRenderer>().enabled;
        var material = res.GetComponent<Renderer>();


        if (isEnabled)
        {
            res.GetComponent<MeshRenderer>().enabled = false;
            Globals.numSelected -= 1;
            material.material.SetColor("_Color",Color.green);
        } else
        {
            res.GetComponent<MeshRenderer>().enabled = true;
            Globals.numSelected += 1;
            material.material.SetColor("_Color" +
                "", Color.green);
        }
        
        
    }
}

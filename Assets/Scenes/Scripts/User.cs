using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class User : ScriptableObject
{

    private System.Guid userID;
    private string userName;
    /* private string name;
     public string Name
     {
         get
         {
             return this.name;
         }
         set
         {
             this.name = value;
         }
     }*/

    public User(System.Guid userID, string userName)
    {
        this.userID = userID;
        this.userName = userName;



    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    


    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//identify each cyclone prefab
public class CycloneID : MonoBehaviour{

    public string ID;
    int idNumber;    

    //increment cyclone ID number
    public string Increment(){

        idNumber++;

        ID = "Cyclone" + idNumber.ToString();
        return ID;
    }    
}

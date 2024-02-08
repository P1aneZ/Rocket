using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMManager : MonoBehaviour
{       
    // Start is called before the first frame update
    void Start()
    {       
        DontDestroyOnLoad(this.gameObject);
    }   
}

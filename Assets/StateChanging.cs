using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanging : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
BaseState st=new BaseState("tile");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
		if(st=="tile")
			ChangeState(st, "meeple");
		if(st=="meeple")
			ChangeState(st, "tile");
    }
}

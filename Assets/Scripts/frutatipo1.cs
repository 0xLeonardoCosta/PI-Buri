using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frutatipo1 : ItemPool
{
    public static frutatipo1 SharedInstance;
    
    ItensControl _itensControl;

    protected override void Awake()
    {
        SharedInstance = this;
    }

    
}

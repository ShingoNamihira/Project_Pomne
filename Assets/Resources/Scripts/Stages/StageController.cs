using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    #region Properties
    public bool GetSetCharacterFlag
    {
        get { return characterFlag;  }
        set { characterFlag = value; }
    }

    public GameObject GetSetCharacter
    {
        get { return characterObject;  }
        set { characterObject = value; }
    }

    public int GetSetArrayI
    {
        get { return arrayI;  }
        set { arrayI = value; }
    }

    public int GetSetArrayJ
    {
        get { return arrayJ;  }
        set { arrayJ = value; }
    }

    #endregion

    #region Public Methods
    public void SetNull()
    {
        characterObject = null;
    }

    #endregion

    #region Private Value
    private bool characterFlag = false;
    private GameObject characterObject;
    private int arrayI;
    private int arrayJ;

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    #region Properties
    //キャラが居るかのフラグ
    public bool GetSetCharacterFlag
    {
        get { return characterFlag;  }
        set { characterFlag = value; }
    }

    //このステージにいるキャラの情報
    public GameObject GetSetCharacter
    {
        get { return characterObject;  }
        set { characterObject = value; }
    }

    //配列のx
    public int GetSetArrayI
    {
        get { return arrayI;  }
        set { arrayI = value; }
    }
    //配列のy
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

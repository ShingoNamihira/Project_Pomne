using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour {

    #region Public Methods
    public GameObject GetSetAssignedObject
    {
        get { return assignedObject;  }
        set { assignedObject = value; }
    }

    public GameObject GetSetStageGeneratorObject
    {
        get { return stageGeneratorObject;  }
        set { stageGeneratorObject = value; }
    }

    #endregion

    #region Private Methods
    private void Start()
    {
        stageController = assignedObject.GetComponent<StageController>();
        stageGenerator  = stageGeneratorObject.GetComponent<StageGenerator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(stageController.GetSetArrayI < stageGenerator.GetStageSize - 1)
            {
                this.gameObject.transform.position = 
            }
        }
    }

    #endregion

    #region SerializeField
   

    #endregion

    #region Private Values
    private GameObject assignedObject;
    private StageController stageController;
    private GameObject stageGeneratorObject;
    private StageGenerator stageGenerator;

    #endregion

}

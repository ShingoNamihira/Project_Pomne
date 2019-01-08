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
        characterGenerator = characterGeneratorObject.GetComponent<CharacterGenerator>();
    }

    private void Update()
    {
        //右を押したとき
        if (moveMode == 0 && Input.GetKey(KeyCode.RightArrow))
        {
            moveMode = 1;
            
        }
        //左を押したとき
        if (moveMode == 0 && Input.GetKey(KeyCode.LeftArrow))
        {
            moveMode = 2;
        }
        //上を押したとき
        if (moveMode == 0 && Input.GetKey(KeyCode.UpArrow))
        {
            moveMode = 3;
        }
        //下を押したとき
        if (moveMode == 0 && Input.GetKey(KeyCode.DownArrow))
        {
            moveMode = 4;
        }

        switch (moveMode)
        {
            case 1:
                int arrayI = stageController.GetSetArrayI;  //配列のiを取得
                int arrayJ = stageController.GetSetArrayJ;  //配列のjを取得
                if (stageController.GetSetArrayJ < stageGenerator.GetStageSize - 1
                && !stageGenerator.GetStageArray[arrayI, arrayJ + 1].GetComponent<StageController>().GetSetCharacterFlag)
                {
                    MoveCharacterX(arrayI, arrayJ, 1);
                }
                else
                {
                    moveMode = 0;
                    CreateCharacter();
                }
                break;

            case 2:
                arrayI = stageController.GetSetArrayI;  //配列のiを取得
                arrayJ = stageController.GetSetArrayJ;  //配列のjを取得
                if (stageController.GetSetArrayJ > 0
                && !stageGenerator.GetStageArray[arrayI, arrayJ - 1].GetComponent<StageController>().GetSetCharacterFlag)
                {
                    MoveCharacterX(arrayI, arrayJ, -1);
                }
                else
                {
                    moveMode = 0;
                    CreateCharacter();
                }
                break;
            case 3:
                arrayI = stageController.GetSetArrayI;  //配列のiを取得
                arrayJ = stageController.GetSetArrayJ;  //配列のjを取得
                if (stageController.GetSetArrayI > 0
                && !stageGenerator.GetStageArray[arrayI - 1, arrayJ].GetComponent<StageController>().GetSetCharacterFlag)
                {
                    MoveCharacterY(arrayI, arrayJ, -1);
                }
                else
                {
                    moveMode = 0;
                    CreateCharacter();
                }
                break;
            case 4:
                arrayI = stageController.GetSetArrayI;  //配列のiを取得
                arrayJ = stageController.GetSetArrayJ;  //配列のjを取得
                if (stageController.GetSetArrayI < stageGenerator.GetStageSize - 1
                && !stageGenerator.GetStageArray[arrayI + 1, arrayJ].GetComponent<StageController>().GetSetCharacterFlag)
                {
                    MoveCharacterY(arrayI, arrayJ, 1);
                }
                else
                {
                    moveMode = 0;
                    CreateCharacter();
                }
                break;
        }
    }

    //X軸方向の移動
    private void MoveCharacterX(int arrayI, int arrayJ, int characterDirection)
    {
        //右/左端でない && 右/左にキャラがいないとき = 右/左に移動
        Vector3 stagePosition = stageGenerator.GetStageArray[arrayI, arrayJ + characterDirection].transform.position;
        this.gameObject.transform.position = new Vector3(stagePosition.x, transform.position.y, stagePosition.z);   //キャラを移動

        //情報の更新
        stageController.GetSetCharacterFlag = false;    //元居たステージのフラグをfalse
        stageController.GetSetCharacter     = null;     //元居たステージのキャラ情報をNull
        stageGenerator.GetStageArray[arrayI, arrayJ + characterDirection].GetComponent<StageController>().GetSetCharacterFlag   = true;    //移動先のフラグをtrue
        stageGenerator.GetStageArray[arrayI, arrayJ + characterDirection].GetComponent<StageController>().GetSetCharacter       = this.gameObject; //移動先のキャラ情報を更新
        assignedObject  = stageGenerator.GetStageArray[arrayI, arrayJ + characterDirection];
        stageController = assignedObject.GetComponent<StageController>();
    }

    //Y軸方向の移動
    private void MoveCharacterY(int arrayI, int arrayJ, int characterDirection)
    {
        //右/左端でない && 右/左にキャラがいないとき = 右/左に移動
        Vector3 stagePosition = stageGenerator.GetStageArray[arrayI + characterDirection, arrayJ].transform.position;
        this.gameObject.transform.position = new Vector3(stagePosition.x, transform.position.y, stagePosition.z);   //キャラを移動

        //情報の更新
        stageController.GetSetCharacterFlag = false;    //元居たステージのフラグをfalse
        stageController.GetSetCharacter = null;     //元居たステージのキャラ情報をNull
        stageGenerator.GetStageArray[arrayI + characterDirection, arrayJ].GetComponent<StageController>().GetSetCharacterFlag = true;    //移動先のフラグをtrue
        stageGenerator.GetStageArray[arrayI + characterDirection, arrayJ].GetComponent<StageController>().GetSetCharacter = this.gameObject; //移動先のキャラ情報を更新
        assignedObject = stageGenerator.GetStageArray[arrayI + characterDirection, arrayJ];
        stageController = assignedObject.GetComponent<StageController>();
    }

    private void CreateCharacter()
    {
        int randomI = Random.Range(0, stageGenerator.GetStageSize - 1);
        int randomJ = Random.Range(0, stageGenerator.GetStageSize - 1);
        GameObject instantCharacter;
        if (stageGenerator.GetStageArray[randomI, randomJ].GetComponent<StageController>().GetSetCharacterFlag != true)
        {
            Debug.Log(characterGenerator);
            instantCharacter = characterGenerator.CharacterCreate(stageGenerator.GetStageArray[randomI, randomJ]);        //生成したキャラ
            stageGenerator.GetStageArray[randomI, randomJ].GetComponent<StageController>().GetSetCharacterFlag = true;    //Stageのキャラフラグをtrueに
        }
        else
        {
            CreateCharacter();
        }
    }

    #endregion

    #region SerializeField
    [SerializeField] GameObject characterGeneratorObject;

    #endregion

    #region Private Values
    private GameObject assignedObject;          //移動時に更新
    private StageController stageController;    //移動時に更新
    private GameObject stageGeneratorObject;    //StartのみでOK
    private StageGenerator stageGenerator;      //StartのみでOK
    private int moveMode = 0;
    private CharacterGenerator characterGenerator;

    #endregion

}


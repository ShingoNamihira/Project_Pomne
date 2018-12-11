using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {

    #region Properties
    public GameObject[,] GetStageArray
    {
        get { return stageArray; }
    }

    public int GetStageSize
    {
        get { return stageSize; }
    }

    #endregion

    #region Private Method
    private void Start()
    {
        float storeX = createPosition.transform.position.x;
        float storeZ = createPosition.transform.position.z;
        for(int i = 0; i < stageSize; i++)
        {
            for(int j = 0; j < stageSize; j++)
            {
                //ステージの生成と配列への格納
                stageArray[i,j] = Instantiate(stagePrefab, 
                    new Vector3(storeX + i + (i * betweenValue), 0, storeZ + j + (j * betweenValue)),
                        Quaternion.identity, parentObject.transform);
                stageArray[i,j].name = "StageObject[" + i + "," + j + "]";
                stageArray[i,j].GetComponent<StageController>().GetSetArrayI = i;
                stageArray[i,j].GetComponent<StageController>().GetSetArrayJ = j;
                
            }
        }

        CharacterGenerator CharacterGenerator = gameObject.GetComponent<CharacterGenerator>();
        //ステージ生成時にキャラを2体生成する
        for (int i = 0; i < 2; i++)
        {
            int random1 = Random.Range(0, stageSize);
            int random2 = Random.Range(0, stageSize);
            GameObject instantCharacter;
            if (stageArray[random1, random2].GetComponent<StageController>().GetSetCharacterFlag != true)
            {
                instantCharacter = CharacterGenerator.CharacterCreate(stageArray[random1, random2]);        //生成したキャラ
                stageArray[random1, random2].GetComponent<StageController>().GetSetCharacterFlag = true;    //Stageのキャラフラグをtrueに
            }
            else
            {
                i = 0;   
                continue;   //かぶっていた場合は再起処理
            }

            stageArray[random1, random2].GetComponent<StageController>().GetSetCharacter = instantCharacter;        //ステージにキャラの情報を渡す
            instantCharacter.GetComponent<CharaController>().GetSetAssignedObject = stageArray[random1, random2];   //生成されたキャラにステージ情報を渡す
            instantCharacter.GetComponent<CharaController>().GetSetStageGeneratorObject = this.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(GameObject iStageObject in stageArray)
            {
                Debug.Log(iStageObject.GetComponent<StageController>().GetSetCharacterFlag + " : " + iStageObject.name);
            }
        }
    }

    StageGenerator()
    {
        stageArray = new GameObject[stageSize, stageSize];
    }

    #endregion

    #region SerializedField
    [SerializeField] GameObject createPosition; //生成される初期ポジション
    [SerializeField] GameObject stagePrefab;    //生成するオブジェクト
    [SerializeField] GameObject parentObject;   //親オブジェクト

    #endregion

    #region Private Values
    private float betweenValue = 0.1f;          //ステージの間隔
    private GameObject[,] stageArray;           //ステージの配列
    private int stageSize = 2;                  //ステージの大きさ

    #endregion
}

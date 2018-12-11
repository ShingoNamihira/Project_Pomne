﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour {

    #region Public Method
    public GameObject CharacterCreate(GameObject iStageObject)
    {
        float createHeight = iStageObject.transform.position.y + CharacterPrefab.transform.localScale.y;
        GameObject instantCharacter = Instantiate(CharacterPrefab, 
            new Vector3(iStageObject.transform.position.x, createHeight, iStageObject.transform.position.z), 
                Quaternion.identity) as GameObject;

        return instantCharacter;
    }

    #endregion

    #region SerializedField
    [SerializeField] private GameObject CharacterPrefab;

    #endregion

    #region Private Value


    #endregion
}

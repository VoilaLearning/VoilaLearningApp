﻿using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

    public static void ResetTransform(this Transform transform) {

        transform.position = Vector3.one;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    public static void SetAllChildrenActive(this Transform transform) {

        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++) {

            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public static int GetActiveChildCount (this Transform transform) {

        int count = 0;

        foreach(Transform child in transform) {

            if(child.gameObject.activeSelf) {

                count++;
            }
        }

        return count;
    }
}

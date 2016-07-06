using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

    public static void SetAllChildrenActive(this Transform transform) {

        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++) {

            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}

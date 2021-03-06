﻿using UnityEditor;
using UnityEngine;

public static class Grouper {

    [MenuItem("Commands/Group %g")]
    public static void GroupSelected() {
        var objects = Selection.gameObjects;
        if (objects.Length == 0)
            return;

        var avgPos = Vector3.zero;
        foreach (var o in Selection.gameObjects) {
            avgPos += o.transform.position;
        }

        avgPos /= Selection.gameObjects.Length;

        var rootObject = new GameObject(objects[0].name + "_Group");
        rootObject.transform.position = avgPos;
        Undo.RegisterCreatedObjectUndo(rootObject, "Create group");
        var rootParent = objects[0].transform.parent;
        Undo.SetTransformParent(rootObject.transform, rootParent, "Create group");

        foreach (var gameObject in Selection.gameObjects) {
            Undo.SetTransformParent(gameObject.transform, rootObject.transform, "Create group");
        }

        Selection.activeGameObject = rootObject;
    }
}
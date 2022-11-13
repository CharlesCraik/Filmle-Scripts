using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomEditorWindow : EditorWindow {

    [MenuItem("Tools/CustomWindow")]
    public static void ShowWindow() {
        GetWindow<CustomEditorWindow>("CustomEditorWindow");
    }

    void OnGUI() {
        GUILayout.Label("Reload Database", EditorStyles.boldLabel);
        if(GUILayout.Button("Reload Database")){
            GameObject.Find("Database").GetComponent<LoadExcel>().loadItemData();
        }

        GUILayout.Label("Clear Data", EditorStyles.boldLabel);
        if(GUILayout.Button("Clear Data")){
            PlayerPrefs.DeleteAll();
            Debug.Log("Data Cleared");
        }

        GUILayout.Label("Test Var Return", EditorStyles.boldLabel);
        if(GUILayout.Button("Test")){
            string movie = "American Psycho";
            char[] myChar = movie.ToCharArray(); // Convert string to char array
            // Jumble char array 
            for (int i = myChar.Length - 1; i > 0; i--)
            {
                int rnd = UnityEngine.Random.Range(0, i);
                char temp = myChar[i];
                myChar[i] = myChar[rnd];
                myChar[rnd] = temp;
            }

            var jumbledWord = new string(myChar);   // Convert char array to string 
            Debug.Log(jumbledWord); // Display jumbled word to screen
        }
    }
}


using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogEditor : EditorWindow
{
    /// <summary>
    /// Open the dialog editor window
    /// </summary>
    [MenuItem("Tools/Dialog Editor")]
    private static void OpenWindow()
    {
        GetWindow<DialogEditor>();
    }

    private Vector2 scrollPosition;
    private int selectedDialogIndex;
    private string[] dialogsAssetsFound;
    private string[] dialogsAssetsFoundLabel;

    string imageName = "null";

    /// <remarks>
    /// This window allows the user to create a new dialog, choose a dialog to edit, 
    /// and edit the strings in the chosen dialog.
    /// </remarks>
    private void OnGUI()
    {
        //Titolo della finestra
        titleContent = new GUIContent("Dialog Editor");

        // CREATE NEW DIALOG
        if (GUILayout.Button("New Dialog"))
        {
            NewDialog();
        }

        // GET ALL DIALOGS
        GetAllDialogs();

        // IF NO DIALOGS FOUND, SHOW ERROR
        if (dialogsAssetsFound.Length == 0)
        {
            EditorGUILayout.HelpBox("No Languages Found", MessageType.Error);
            return;
        }

        // CHOOSE DIALOG
        /// <summary>
        /// Choose the dialog to edit
        /// </summary>
        /// <remarks>
        /// This is a dropdown list that shows the names of all the dialogs in the project
        /// and allows the user to choose one to edit.
        /// </remarks>
        selectedDialogIndex = EditorGUILayout.Popup("Dialogs",
            selectedDialogIndex, dialogsAssetsFoundLabel);

        // SHOW CHOSEN DIALOG
        GUILayout.Label(dialogsAssetsFound[selectedDialogIndex]);

        // LOAD THE CHOSEN DIALOG
        /// <summary>
        /// Load the chosen dialog
        /// </summary>
        /// <remarks>
        /// This loads the chosen dialog into memory and makes it available for editing.
        /// </remarks>
        DialogSO dialog = 
            AssetDatabase.LoadAssetAtPath<DialogSO>(dialogsAssetsFound[selectedDialogIndex]);

        // SCROLL VERTICAL
        /// <summary>
        /// Make the dialog list scrollable
        /// </summary>
        /// <remarks>
        /// This allows the user to scroll up and down in the dialog list
        /// if there are more strings than can fit in the window.
        /// </remarks>
        scrollPosition = 
            EditorGUILayout.BeginScrollView(scrollPosition);

        // DISPLAY DIALOG
        GUILayout.Label("DIALOG LIST");
        GUILayout.Space(5f);

        // DISPLAY STRINGS
        for (int i = 0; i < dialog.sentences.Count; i++)
        {
            if (dialog.sentences[i].characterSprite != null)
            {
                imageName = dialog.sentences[i].characterSprite.ToString();
            }

            EditorGUILayout.BeginHorizontal();

            // CHARACTER NAME
            /// <summary>
            /// Show the character name
            /// </summary>
            /// <remarks>
            /// This shows the character name associated with the current string.
            /// If the character name is empty, it shows the string "null" instead.
            /// </remarks>
            EditorGUILayout.LabelField(dialog.sentences[i].characterName, 
                imageName != null ? imageName : "null");

            // STRING CONTENT
            GUILayout.Space(15f);

            GUILayout.Label(dialog.sentences[i].line);

            // EDIT STRING
            if (GUILayout.Button("e", EditorStyles.miniButtonLeft, GUILayout.Width(25f)))
            {
                EditDialogLineWindow editDialogLineWindow = EditorWindow.GetWindow<EditDialogLineWindow>();

                editDialogLineWindow.stringIndex = i;
                editDialogLineWindow.stringContent = dialog.sentences[i].line;
                editDialogLineWindow.characterName = dialog.sentences[i].characterName;
                editDialogLineWindow.dialog = dialog;
                editDialogLineWindow.characterSprite = dialog.sentences[i].characterSprite.texture;
            }

            if(GUILayout.Button("+", EditorStyles.miniButtonMid, GUILayout.Width(25f))) 
            {  
                AddString(i, ref dialog);
            }

            // REMOVE STRING
            if (GUILayout.Button("-", EditorStyles.miniButtonRight, GUILayout.Width(25f)))
            {
                if (EditorUtility.DisplayDialog("Confirm",
                    $"Do you really want to remove the string {dialog.sentences[i].line}?",
                    "YES",
                    "NO"))
                {
                    RemoveString(dialog.sentences[i].line);
                    break;
                }

            }

            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();
    }

    /// <summary>
    /// Add a new string at the specified index in the Dialog
    /// </summary>
    /// <param name="index">The index at which to add the new string</param>
    /// <param name="dialog">The Dialog to modify</param>
    private void AddString(int index, ref DialogSO dialog)
    {
        // Create a new Sentence with empty values
        Sentence newSentence = new Sentence("", null, "");

        // Insert the new Sentence at the specified index
        dialog.sentences.Insert(index + 1, newSentence);
    }

    /// <summary>
    /// Search all the Dialog assets in the project and
    /// store their paths in the dialogsAssetsFound array.
    /// </summary>
    private void GetAllDialogs()
    {
        // Find all the Dialog assets in the project
        dialogsAssetsFound = AssetDatabase.FindAssets("t: DialogSO");

        // Create a label array to store the asset names
        dialogsAssetsFoundLabel = new string[dialogsAssetsFound.Length];

        // Iterate over the found assets and store their paths and names
        for (int i = 0; i < dialogsAssetsFound.Length; i++)
        {
            // Get the path of the asset
            dialogsAssetsFound[i] = 
                AssetDatabase.GUIDToAssetPath(dialogsAssetsFound[i]);

            // Get the name of the asset
            dialogsAssetsFoundLabel[i] = 
                Path.GetFileName(dialogsAssetsFound[i]);

            // Print a debug message
            // Debug.Log($"Trovato: {dialogsAssetsFound[i]}");
        }
    }

    /// <summary>
    /// Create a new Dialog asset
    /// </summary>
    private void NewDialog()
    {
        // Ask the user where to save the new Dialog asset
        string path = EditorUtility.SaveFilePanelInProject("New Dialog Asset",
            "NewDialog",
            "asset",
            "New Dialog Saved!");

        if (!string.IsNullOrEmpty(path))
        {
            // Create a new instance of the Dialog class
            DialogSO newDialog = CreateInstance<DialogSO>();

            // Set the name of the new Dialog asset to the specified path
            AssetDatabase.CreateAsset(newDialog, path);

            // Mark the new Dialog asset as dirty to save it
            EditorUtility.SetDirty(newDialog);
        }
    }

    /// <summary>
    /// Remove a string from all the languages in the project.
    /// This method is called when the user clicks on the "-" button
    /// in the Dialog Editor window.
    /// </summary>
    /// <param name="line">The string to remove.</param>
    private void RemoveString(string line)
    {
        // Iterate over all the languages in the project
        foreach (string languagePath in dialogsAssetsFound)
        {
            // Load the language asset
            DialogSO language = AssetDatabase.LoadAssetAtPath<DialogSO>(languagePath);

            // Remove all the sentences that match the given line
            language.sentences.RemoveAll(s => s.line == line);

            // Mark the language asset as dirty to save the changes
            EditorUtility.SetDirty(language);
        }
    }
}


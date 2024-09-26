using UnityEditor;
using UnityEngine;

public class EditDialogLineWindow : EditorWindow
{
    public int stringIndex;
    public string stringContent;
    public string characterName;
    public Sprite characterSprite;
    public DialogSO dialog;
    public bool confirm;

    private void OnGUI()
    {
        // Set the title of the window
        titleContent = new GUIContent("Edit Dialog Line");

        // Create a label to show the character name
        GUILayout.Label("Character Name");

        // Create a text field to edit the character name
        // The current value of the character name is passed as an argument
        // The changed value is stored back in the characterName field
        characterName = EditorGUILayout.TextField(characterName);

        // Start a horizontal layout to place the character sprite and its label side by side
        GUILayout.BeginHorizontal();

        // If there is a character sprite set
        if(characterSprite != null)
        {
            // Get the sprite's texture
            Sprite mySprite = characterSprite;
            Rect textureRect = mySprite.textureRect;

            // Create a box that displays the texture
            // The box will have the same width and height as the texture
            GUILayout.Box(mySprite.texture, GUILayout.Width(textureRect.width), GUILayout.Height(textureRect.height));
        }

        // Create a label to show the character sprite
        // This label will be placed to the right of the box containing the sprite
        GUILayout.Label("Character Sprite");
        // Create a input field to insert a sprite
        // The current value of the character sprite is passed as an argument
        // The changed value is stored back in the characterSprite field
        characterSprite = (Sprite)EditorGUILayout.ObjectField(characterSprite, typeof(Sprite), false);

        GUILayout.EndHorizontal();

        // Create a label to show the content
        GUILayout.Label("Content");

        // Create a text area to edit the content
        // The current value of the content is passed as an argument
        // The changed value is stored back in the stringContent field
        // The GUILayout.ExpandHeight(true) parameter makes the text area expand to fill the available space
        stringContent = EditorGUILayout.TextArea(stringContent, GUILayout.ExpandHeight(true));

        // Add some space between the text area and the buttons
        GUILayout.Space(25f);

        // Begin a horizontal layout for the buttons
        GUILayout.BeginHorizontal();

        // Create a button to save the changes
        if (GUILayout.Button("Save"))
        {
            // Call the SaveChange method to save the changes
            SaveChange();
        }

        // Create a button to save the changes and close the window
        if (GUILayout.Button("OK"))
        {
            // Call the SaveChange method to save the changes
            SaveChange();

            // Close the window
            Close();
        }

        // Create a button to cancel and close the window
        if (GUILayout.Button("Cancel"))
        {
            // Close the window
            Close();
        }

        // End the horizontal layout
        GUILayout.EndHorizontal();
    }

    private void SaveChange()
    {
        confirm = true;
        dialog.sentences[stringIndex].UpdateLine(stringContent);
        dialog.sentences[stringIndex].UpdateCharacterName(characterName);
        dialog.sentences[stringIndex].UpdateCharacterSprite(characterSprite);
    }
}

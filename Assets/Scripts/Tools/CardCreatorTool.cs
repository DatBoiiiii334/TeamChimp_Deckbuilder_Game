using UnityEngine;
using UnityEditor;

public class CardCreatorTool : EditorWindow
{
    //public GameObject Spawner;
    //private Card myCard;
    GameObject gameObject;
    Editor gameObjectEditor;
    Texture2D previewBackgroundTexture;

    [MenuItem("DevTools/CardCreatorTool")]
    public static void ShowWindow()
    {
        GetWindow<CardCreatorTool>("Card Creator Tool");
    }

    void OnGUI()
    {
        //GUILayout.Label("hello world", EditorStyles.boldLabel);

        //if (GUILayout.Button("Create Card"))
        //{
        //    //Do the thing
        //    Create();
        //}

        EditorGUI.BeginChangeCheck();
   
        gameObject = (GameObject) EditorGUILayout.ObjectField(gameObject, typeof(GameObject), true);
   
        if(EditorGUI.EndChangeCheck())
        {
            if(gameObjectEditor != null) DestroyImmediate(gameObjectEditor);
        }
   
        GUIStyle bgColor = new GUIStyle();
   
        bgColor.normal.background = previewBackgroundTexture;
   
        if (gameObject != null)
        {
            if (gameObjectEditor == null)
       
            gameObjectEditor = Editor.CreateEditor(gameObject);
            gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect (200,200),bgColor);
        }
    }



    void Create()
    {
        //GameObject CurrentEntity = Instantiate(Spawner, new Vector3(0,0,0), Quaternion.identity);
        //Card myCard = Instantiate(Resources.Load("Resources/CardProfiles")) as Card;
        //Card myCard;
        //myCard = Resources.Load<Card>("CardProfiles") as Card;
        //Card myCard = Resources.Load("cards") as Card;
        //myCard.name = "Erik";
        //myCard.Description = "Hello Cruel World";
        //myCard.Mana = 7;
        //myCard.AttackDamage = 10;
        //myCard.Health = 100;
    }

}

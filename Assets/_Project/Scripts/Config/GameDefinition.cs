using UnityEngine;

[CreateAssetMenu(fileName = "NewGameDefinition", menuName = "GameDefinitions/GameDefinition")]
public class GameDefinition : ScriptableObject
{
    public string GameName;
    public string SceneName;
    public Sprite Icon;
}

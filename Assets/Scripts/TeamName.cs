using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeamName : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI tmpText1;
    public TextMeshProUGUI tmpText2;
    public TextMeshProUGUI tmpText3;

    void Start()
    {
        inputField.characterLimit = 20;
        inputField.onValueChanged.AddListener(UpdateText);
    }

    void UpdateText(string newValue)
    {
        // Update the TextMeshPro text with the value from the InputField
        tmpText1.text = newValue;
        tmpText2.text = newValue;
        tmpText3.text = newValue;
    }
}

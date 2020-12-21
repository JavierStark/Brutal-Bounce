using UnityEngine;
using TMPro;

public class ConsejosContextuales : MonoBehaviour
{

    public TMP_Text textC;

    [TextArea(1, 5)]
    public string[] consejos;

    private void Awake() {

        int rand = Random.Range(0, consejos.Length);
        textC.text = consejos[rand].ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Multilanguage : ScriptableObject
{
    public TextItem[] textItems;

    [System.Serializable]
    public class TextItem
    {
        [TextArea(2, 10)]
        public string[] translation;
    }
}

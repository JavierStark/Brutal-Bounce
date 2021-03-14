using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionText : MonoBehaviour
{
    TMPro.TMP_Text versionText;

    void Awake()
    {
        versionText = GetComponent<TMPro.TMP_Text>();
    }

    void Start()
    {
        versionText.text = "v" + Application.version;
    }

    // Update is called once per frame
    void Update()
    {

    }

}

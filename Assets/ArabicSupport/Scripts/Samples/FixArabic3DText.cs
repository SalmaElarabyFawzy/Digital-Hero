using UnityEngine;
using System.Collections;
using ArabicSupport;
using TMPro;

public class FixArabic3DText : MonoBehaviour {

    public bool showTashkeel = true;
    public bool useHinduNumbers = true;
    public TextMeshProUGUI textMesh;
    // Use this for initialization
    void Start () {
        string fixedText = ArabicFixer.Fix(textMesh.text, showTashkeel, useHinduNumbers);

        textMesh.text = fixedText;

		Debug.Log(fixedText);
    }

}

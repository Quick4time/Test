using System.Collections;
using UnityEngine;

namespace TMPro
{
    // Сделать через EventManager
    public class LocalizTestScr : MonoBehaviour
    {
        private TextMeshProUGUI m_textMeshPro;

        [LocalizationTextAttribute("pressbutton")]
        public string PressButtonText = string.Empty;

        void Awake()
        {
            m_textMeshPro = GetComponent<TextMeshProUGUI>();           
        }
        private void Update()
        {
            m_textMeshPro.text = PressButtonText;
        }
    }
}



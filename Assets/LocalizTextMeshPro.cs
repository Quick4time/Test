using System.Collections;
using UnityEngine;

namespace TMPro.Examples
{
    public class simscr : MonoBehaviour
    {

        private TMP_Text m_textMeshPro;
        //private TMP_FontAsset m_FontAsset;

        private string[] label;
        private float m_frame;
        private TMP_FontAsset m_FontAssets;

        void Awake()
        {
            m_textMeshPro = gameObject.AddComponent<TextMeshPro>();

        }

        IEnumerator Start()
        {

            m_textMeshPro.text = "Run away ";

            // Add new TextMesh Pro Component
            //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF - Overlay", typeof(Material)) as Material;
            //m_textMeshPro.isOverlay = true;
            // Load the Font Asset to be used.
            //m_FontAsset = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
            //m_textMeshPro.font = m_FontAsset;

            // Assign Material to TextMesh Pro Component
            //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF - Bevel", typeof(Material)) as Material;
            //m_textMeshPro.fontSharedMaterial.EnableKeyword("BEVEL_ON");


            // Set various font settings.


            //m_textMeshPro.anchorDampening = true; // Has been deprecated but under consideration for re-implementation.
            //m_textMeshPro.enableAutoSizing = true;

            //m_textMeshPro.characterSpacing = 0.2f;
            //m_textMeshPro.wordSpacing = 0.1f;

            //m_textMeshPro.enableCulling = true;

            m_textMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
            int counter = 0;
            int visibleCount = 0;


            while (true && visibleCount != totalVisibleCharacters)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

                m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?


                counter += 1;

                yield return new WaitForSeconds(0.2f);
            }
            //textMeshPro.fontColor = new Color32(255, 255, 255, 255);
        }

    }
}



using TMPro;
using UnityEngine;

public class PlayerPrefsExample : MonoBehaviour
{

    public float m_Health = 10f;

    private TextMeshProUGUI m_TextMeshProUGUI;
    private const string HEALTH_KEY = "Health";

    private int colorID = Shader.PropertyToID("_Color");

    private void Start()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // health = 0

            Debug.Log(m_Health++); // 0

            // health = 1

            Debug.Log(++m_Health); // 2

            // health = 2
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_Health--;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            PlayerPrefs.SetFloat(HEALTH_KEY, m_Health);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if(PlayerPrefs.HasKey(HEALTH_KEY))
            {
                m_Health = PlayerPrefs.GetFloat(HEALTH_KEY);
            }
        }

        m_TextMeshProUGUI.text = "Health: " + m_Health; 
    }

    void foo(float h)
    {
        Debug.Log(h);
    }
}

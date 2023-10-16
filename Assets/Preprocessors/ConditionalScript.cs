
using UnityEngine;
public class ConditionalScript : MonoBehaviour
{
    #region Private Attributes
    Renderer _Renderer;
    #endregion

    #region Unity Methods
    void Start()
    {
        _Renderer = GetComponent<Renderer> (); 
    }

    // Update is called once per frame
    void Update()
    {
#pragma warning disable 0168
        int variable;
#pragma warning restore 0168

#if DEBUG_CUSTOM
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
#endif
    }
    #endregion

    void ChangeColor()
    {
        _Renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

}

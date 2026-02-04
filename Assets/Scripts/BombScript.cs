/*using UnityEngine;

public class BombScript : MonoBehaviour
{
    public bool hasBomb = false; // الصندوق فيه قنبلة أو لا

    void Start()
    {
        
    }

    public void CheckMask(bool maskOn)
    {
        if (maskOn && hasBomb)
        {
           gameObject.SetActive(false); // الصندوق يختفي إذا فيه قنبلة والماسك شغال
        }
        else
        {
            gameObject.SetActive(true); // يرجع يظهر
        }
    }
}
*/
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public bool hasBomb = true;

    SpriteRenderer boxSR;
    Collider2D boxCol;

    GameObject bomb; // الطفل

    void Awake()
    {
        boxSR = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<Collider2D>();

        bomb = transform.GetChild(0).gameObject;

        // بالبداية القنبلة مخفية
        bomb.SetActive(false);
    }

    public void CheckMask(bool maskOn)
    {
        if (maskOn && hasBomb)
        {
            // اختفي الصندوق
            boxSR.enabled = false;
            boxCol.enabled = false;

            // أظهر القنبلة
            bomb.SetActive(true);
        }
        else
        {
            // رجع الصندوق
            boxSR.enabled = true;
            boxCol.enabled = true;

            // أخفي القنبلة
            bomb.SetActive(false);
        }
    }
}

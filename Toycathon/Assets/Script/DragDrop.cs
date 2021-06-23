using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    public Camera cam;
    RectTransform rect;
    Rigidbody2D rbd;
    [SerializeField] Canvas canvas;
    public CanvasGroup CanvasGrp;
    public float multiplicant = 10f;

    Vector2 StartPos;
    public bool Locked = false;

    void Awake()
    {

        rbd = GetComponent<Rigidbody2D>();
        rect = GetComponent<RectTransform>();
        CanvasGrp = GetComponent<CanvasGroup>();
        StartPos = rect.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        CanvasGrp.alpha = 0.6f;
        CanvasGrp.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / (canvas.scaleFactor);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CanvasGrp.alpha = 1f;
        rbd.constraints = RigidbodyConstraints2D.FreezeAll;
        if (!Locked)
        {
            CanvasGrp.blocksRaycasts = true;
            ResetPos();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void ResetPos()
    {
        rbd.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        rect.anchoredPosition = StartPos;
    }

    public void ResetDialog()
    {
        ResetPos();
        Locked = false;
        CanvasGrp.blocksRaycasts = true;
    }
}
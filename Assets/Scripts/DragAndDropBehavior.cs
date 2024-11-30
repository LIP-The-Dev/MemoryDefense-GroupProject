using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropBehavior : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField] private float GridSize = 1f;
    [SerializeField] private float rotationStep = 90f;
    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        SnapToGrid();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }
    
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            RotateTower();
        }
    }
    
    private void RotateTower()
    {
        float currentRotation = transform.eulerAngles.z;
        float newRotation = Mathf.Round((currentRotation + Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")) * rotationStep) / rotationStep) * rotationStep;
        transform.eulerAngles = new Vector3(0, 0, newRotation);
    }

    public void SnapToGrid()
    {
        Vector3 position = rectTransform.anchoredPosition;
        position.x = Mathf.Round(position.x / GridSize) * GridSize;
        position.y = Mathf.Round(position.y / GridSize) * GridSize;
        rectTransform.anchoredPosition = position;
    }
}

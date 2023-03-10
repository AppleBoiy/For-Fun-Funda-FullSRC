using UnityEngine;
using UnityEngine.EventSystems;

namespace DraggableObj
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform _rectTransform;
        public Canvas canvas;
        private CanvasGroup _canvasGroup;
        public Vector2 initPos;
        
        public int id;
        public string type;
        public string room;
    
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            initPos = transform.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("CLICK");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("BeginDrag");
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("EndDrag");
            _canvasGroup.blocksRaycasts = true;
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
        }

        public void ResetPosition()
        {
            transform.position = initPos;
        }

        public void Destroy()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    
    }
}

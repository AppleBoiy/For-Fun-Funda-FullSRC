using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DragableObj
{
   public class SlotScript : MonoBehaviour, IDropHandler
   {
   
      [Header("Score Collect item scene")]
      [SerializeField] private int collectCount;
      private int _totalCount;
      private int _totalScore;
   
      [Header("Counter scene")]
      [SerializeField] public GameObject nextGameDialogBox;

      [Header("Object to show")]
      [SerializeField] private GameObject wrongItemGet;
      [SerializeField] private GameObject correctItemGet;
      [SerializeField] private GameObject showObj1;
      [SerializeField] private GameObject showObj2;
      [SerializeField] private GameObject objectToShow;
      [SerializeField] private GameObject objectToHide;
      private WaitForSeconds _waitForSeconds;

      public void OnDrop(PointerEventData eventData)
      {
         Debug.Log("OnDrop");
         if (eventData.pointerDrag != null)
         {
         
            //ID 0 = Show more object ondrop
            //ID 1 = Drop to Hide and show object
            //ID 2 = Collect Item
            //ID ELSE = False
         
            Vector2 outSidePosition = new Vector2(10000, 10000);
            switch (eventData.pointerDrag.GetComponent<DragAndDrop>().id)
            {
               
               //Show more object ondrop
               case 0:
                  eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = outSidePosition;
                  _totalCount++;
                  if (_totalCount >= collectCount)
                  {
                     showObj1.SetActive(true);
                     showObj2.SetActive(true);
                  }
                  break;
               
               //Drop to Hide and show object
               case 1:
                  eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = outSidePosition;
                  objectToHide.SetActive(false);
                  objectToShow.SetActive(true);
                  break;
               
               //Drop in score count
               case 2:
                  Debug.Log("Collect!!");
                  eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = outSidePosition;
                  StartCoroutine(Wait(2));
                  _totalCount++;
                  if (_totalCount >= collectCount)
                  {
                     nextGameDialogBox.SetActive(true);
                     correctItemGet.SetActive(false);
                  }
                  break;
               
               //Reset and check type
               case 3:
                  eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition();
                  StartCoroutine(Wait(3));
                  break;
               
               //Collect object
               case 4:
                  eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =  GetComponent<RectTransform>().anchoredPosition;
                  objectToHide.SetActive(false);
                  objectToShow.SetActive(true);
                  break;
               
               //Default
               default:
                  Debug.Log("False!!");
                  eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition();
                  break;
            }
            
         }
      }
   
      // ReSharper disable Unity.PerformanceAnalysis
      private IEnumerator Wait(int id)
      {
         Debug.Log("Wait");
         switch (id)
         {
            case 3:
               wrongItemGet.SetActive(true);
               break;
            case 2:
               correctItemGet.SetActive(true);
               break;
         }
      
         yield return new WaitForSeconds(1);
      
         switch (id)
         {
            case 3:
               wrongItemGet.SetActive(false);
               break;
            case 2:
               correctItemGet.SetActive(false);
               break;
         }
      }

      public void OnDrop(PointerEventData eventData, out Vector2 anchoredPos)
      {
         throw new System.NotImplementedException();
      }
   }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
public class TouchCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerCtrl player;
    [Header("Player Transform")]
    public Transform playerTransform;   
    private float referenceSizeX;
    [Header ("GameObject/Buton")]
    public GameObject hideBtn;
    public GameObject jumpBtn;
    private bool jumpActive, hideActive;
    public static TouchCtrl touchCtrl;
    // Use this for initialization
    private void Awake()
    {
        if (touchCtrl == null)
        {
            touchCtrl = this;
        }
    }
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();
        referenceSizeX = Screen.width/2;
        jumpActive = false;
        hideActive = false;
	}

    public void SetJumpActive(bool value) {
        jumpActive = value;
    }

    public void SetHideActive(bool value)
    {
        hideActive = value;
    }

    /*//
     * private void Update()
    {
        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            // Go Left
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if (Input.touches[0].position.x < referenceSizeX)
                {
                    LeftPressed();
                    RightUnpressed();

                }
                else if (Input.touches[0].position.x > referenceSizeX)
                {
                    RightPressed();
                    LeftUnpressed();
                }
            }
            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                player.StopMoving();
            }
        }


        #endregion

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(playerTransform.position.x);
            Debug.Log(Input.mousePosition.x);
            if (Input.mousePosition.x < referenceSizeX)
            {
                RightUnpressed();
                LeftPressed();
            }
            else if (Input.mousePosition.x > referenceSizeX)
            {
                LeftUnpressed();
                RightPressed();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            player.StopMoving();
            RightUnpressed();
            LeftUnpressed();
        }
        #endregion
    }
    //*/

    public void LeftPressed() {
        player.SetLefPressed(true);
    }

    public void LeftUnpressed()
    {
        player.SetLefPressed(false);
        player.StopMoving();
    }

    public void RightPressed()
    {
        player.SetRightPressed(true);
        player.StopMoving();
    }

    public void RightUnpressed()
    {
        player.SetRightPressed(false);
    }

    public void JumpPressed()
    {
        player.SetJumpPressed(true);
    }

    public void JumpUnpressed()
    {
        player.SetJumpPressed(false);
    }

    public void HidePressed()
    {
        player.SetHidePressed(true);
    }

    public void HideUnpressed()
    {
        player.SetHidePressed(false);
    }
    /*#region Mobile Inputs
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.position.x < referenceSizeX)
        {
            LeftPressed();
            RightUnpressed();

        }
        else if (eventData.position.x > referenceSizeX)
        {
            RightPressed();
            LeftUnpressed();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeftUnpressed();
        RightUnpressed();
        player.StopMoving();
    }
    #endregion*/
    //#region Standalone Inputs
    public void OnPointerDown(PointerEventData eventData)
    {
        //if (!jumpActive && !hideActive) {
            if (eventData.position.x < referenceSizeX)
            {
                LeftPressed();
                RightUnpressed();

            }
            else if (eventData.position.x > referenceSizeX)
            {
                RightPressed();
                LeftUnpressed();
            }
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeftUnpressed();
        RightUnpressed();
        player.StopMoving();
    }
    //#endregion
}

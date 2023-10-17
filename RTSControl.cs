// source：https://www.bilibili.com/video/BV1tB4y1J7ra/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Diagnostics;


public class RTSControl : MonoBehaviour
{
    [Header("Selected unit condition parameter")]
    [SerializeField] private RectTransform _selectedLineBox;
    [SerializeField] private LayerMask _utilsLayer;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _dragDelay = 0.1f;
    private float _onMouseDownTime;
    private Vector2 _startPos;
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
        _selectedLineBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UtilsSelectionInputs();
        UtilsMovementInputs();
    }
    private void UtilsMovementInputs()
    {
        HashSet<RTSUtils> utils = RTSManager.Instance.SelectedRtsUtilsSet;
        if (Input.GetMouseButtonDown(1) && utils.Count > 0)
        {
            Debug.Log("Right mouse button and selected unit exists");
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitinfo, 100))
            {
                Debug.Log("Right mouse click position for terrain");
                foreach (var eachUtils in utils)
                {
                    Debug.Log("Move");
                    eachUtils.DoMove(hitinfo.point);
                }
            }
        }
    }

    private void UtilsSelectionInputs()
    {
        float time = Time.time;
        if (Input.GetMouseButtonDown(0))
        {
            _selectedLineBox.sizeDelta = Vector2.zero;
            _selectedLineBox.gameObject.SetActive(true);
            _startPos = Input.mousePosition;
            _onMouseDownTime = time;
        }

        else if (Input.GetMouseButton(0) && _onMouseDownTime + _dragDelay < time)
        {
            ResizeSelectionBox();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            _selectedLineBox.sizeDelta = Vector2.zero;
            _selectedLineBox.gameObject.SetActive(false);
            _onMouseDownTime = 0f;
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, _utilsLayer)
                && hitInfo.collider.TryGetComponent(out RTSUtils utils))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    if (RTSManager.Instance.IsSelected(utils))
                    {
                        RTSManager.Instance.DeSelected(utils);
                    }
                    else
                    {
                        RTSManager.Instance.Selected(utils);
                    }

                }

                else
                {
                    RTSManager.Instance.DeSelectedAll();
                    RTSManager.Instance.Selected(utils);
                }
            }
            else if (_onMouseDownTime + _dragDelay > time)
            {
                RTSManager.Instance.DeSelectedAll();
            }
        }
    }

    private void ResizeSelectionBox() 
    {
        float width = Input.mousePosition.x - _startPos.x;
        float height = Input.mousePosition.y - _startPos.y;

        _selectedLineBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        _selectedLineBox.anchoredPosition = _startPos + new Vector2(width / 2, height / 2);

        Bounds bounds = new Bounds(_selectedLineBox.anchoredPosition, _selectedLineBox.sizeDelta);

        foreach (var eachUtil in RTSManager.Instance.AvailbleRtsUtilsList) 
        {
            if (UtilsInBox(_camera.WorldToScreenPoint(eachUtil.transform.position), bounds))
            {
                RTSManager.Instance.Selected(eachUtil);

            }
            else
            {
                RTSManager.Instance.DeSelected(eachUtil);
            }

        }

    }
    private bool UtilsInBox(Vector2 pos, Bounds bos)
    {
        return pos.x > bos.min.x 
            && pos.x < bos.max.x 
            && pos.y > bos.min.y
            && pos.y < bos.max.y;
           
    }
}

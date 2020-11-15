using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{
    public GameObject GameObject;
    private Game GameScriptInstance;
    public Transform prefab;
    public GameObject spawnedShapesParent;
    public Material defaultPaint;

    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        GameScriptInstance = GameObject.GetComponent<Game>();
        prefab.GetComponent<MeshRenderer>().material = defaultPaint;
    }

    // Update is called once per frame
    void Update()
    {
        MouseHandler();
    }

    private void MouseHandler()
    {
        //if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse) && EventSystem.current.IsPointerOverGameObject() == false)
        if (Input.GetMouseButton((int)MouseButton.LeftMouse) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Debug.Log(MouseButton.LeftMouse);

            GameObject hitTemp = RayCasting();

            if (hitTemp != null)
            {
                PrintObjectName(hitTemp);
                PaintTagReader(hitTemp);
            }
        } //else if (Input.GetMouseButtonDown((int)MouseButton.RightMouse))// && EventSystem.current.IsPointerOverGameObject() == true)
        else if (Input.GetMouseButton((int)MouseButton.RightMouse))// && EventSystem.current.IsPointerOverGameObject() == true)
        {
            Debug.Log(MouseButton.RightMouse);
            
            GameObject hitTemp = RayCasting();

            if (hitTemp != null)
            {
                PrintObjectName(hitTemp);
                //if (hitTemp.tag == "SpawnedObject")
                    KillObject(hitTemp);
            }

        }
        /*       else if (Input.GetMouseButtonDown((int)MouseButton.RightMouse) && EventSystem.current.IsPointerOverGameObject() == false)
               {
                   Debug.Log(MouseButton.RightMouse);

                   GameObject hitTemp = RayCasting();

                   if (hitTemp != null)
                   {
                       PrintObjectName(hitTemp);
                       PaintTagReader(hitTemp);
                   }

               }*/
    }

    private GameObject RayCasting()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 20.0f))
        {
            if(hit.transform != null)
            {
                nextPos = hit.point;
                
                return hit.collider.gameObject;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }

    }

    private void PrintObjectName(GameObject gameObject)
    {
        Debug.Log(gameObject.name);
    }

    private void PaintTagReader(GameObject gameObject)
    {
        if (gameObject.tag == "Brush")
        {
            Debug.Log(gameObject.tag);


            UpdateBrush(gameObject);
        }
        else if (gameObject.tag == "SpawnedObject")
        {
            Debug.Log(gameObject.tag);
        }
        else if (gameObject.tag == "Background")
        {
            Debug.Log(gameObject.tag);

            DrawSphere(gameObject);
        }
        else if(gameObject.tag == "UIElement")
        {
            Debug.Log(gameObject.tag);
        }

    }

    private void KillObject(GameObject gameObject) {
        Debug.Log(gameObject.tag);

        if (gameObject.tag == "SpawnedObject")
        {
            GameScriptInstance.UpdateHighscore(GameScriptInstance.CurrentHighscore - 1);

            gameObject.GetComponent<KillThis>().KillThisObject();

            //if (gameObject != null)
             //   Destroy(gameObject.gameObject);
        }
    }


    private void UpdateBrush(GameObject gameObject)
    {
        //GameScriptInstance.CurrentBrush = gameObject;
        prefab.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;

    }

    private void DrawSphere(GameObject gameObject)
    {
        //        nextPosX = Math.Round(Input.mousePosition.x, 0);
        //        nextPosY = Math.Round(Input.mousePosition.y, 0);
        //nextPosX = Math.Round(, 0);
        //nextPosY = Math.Round(, 0);

        GameScriptInstance.UpdateHighscore(GameScriptInstance.CurrentHighscore + 1);
        //I think there needs to be a plane check with plane in (x, y) so that we are not generating spheres within each other at that exact point. I think
        //The tagReader method logic can handle it where it specifies the "background" tag should be a good way to see if the area is empty for sphere generation
        // I think when the object is spawned you could also reference the GameScriptInstance method "UpdateHighscore" to increment / decrement the updated score. I think .Currenthighscore + 1 or -1


    //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    //Instantiate(prefab, new Vector3(nextPosX, nextPosY, 0), Quaternion.identity).transform.parent = spawnedShapesParent.transform;
    Instantiate(prefab, new Vector3(nextPos.x, nextPos.y, 0), Quaternion.identity).transform.parent = spawnedShapesParent.transform;



    }

    private void EraseSphere()
    {

    }
}

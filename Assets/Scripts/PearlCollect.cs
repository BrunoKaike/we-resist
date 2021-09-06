using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PearlCollect : MonoBehaviour
{
    public float SpeedCollect;
    public GameObject PearlPrefab;
    public Transform target;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
            cam = Camera.main;
    }

    public void StartPearlMove(Vector3 initialPos)
    {
        Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        GameObject _pearl = Instantiate(PearlPrefab, transform);

        StartCoroutine(MovePearl(_pearl.transform, initialPos, targetPos));
    }

    private IEnumerator MovePearl(Transform newPearl, Vector3 startPosition, Vector3 endPosition)
    {
        float time = 0;

        while(time < 1)
        {
            time += SpeedCollect * Time.deltaTime;
            newPearl.position = Vector3.Lerp(gameObject.transform.position, endPosition, time);
            
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}


using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLenght = 2f;

    private void Update()
    {
        Time.timeScale += (1f / slowdownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        if (Input.GetKeyDown(KeyCode.RightControl) && Input.GetKeyDown(KeyCode.RightControl))
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }
    }

    //void DoSlowmotion ()
    //{
        //Time.timeScale = slowdownFactor;
        //Time.fixedDeltaTime = Time.timeScale * .02f;
    //}
}

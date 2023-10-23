using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeandquit : MonoBehaviour
{
   public GameObject pausemenu;

   public void resume()
   {
       pausemenu.SetActive(false);
       Time.timeScale = 1f;
   }

   public void quit()
   {
       Application.Quit();
   }
}

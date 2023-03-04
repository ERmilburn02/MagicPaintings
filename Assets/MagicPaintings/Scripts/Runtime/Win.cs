using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicPaintings.Menus
{
    public class Win : MonoBehaviour
    {
        public void OnMenuButtonClick()
        {
            Loader.Instance.LoadMenu();
        }
    }
}

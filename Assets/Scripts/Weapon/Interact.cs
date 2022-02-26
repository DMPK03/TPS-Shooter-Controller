using System;
using System.Collections.Generic;
using UnityEngine;


namespace Dmpk_TPS
{
    public static class Interact
    {
        public static event Action<IInteractable, bool> InteractableEvent;

        public static void Interactable(IInteractable sender, bool active)
        {
            if(InteractableEvent != null)
                InteractableEvent(sender, active);
        }

    }

}

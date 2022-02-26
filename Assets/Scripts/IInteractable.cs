using System;
using System.Collections.Generic;
using UnityEngine;


namespace Dmpk_TPS
{
    public interface IInteractable
    {        
        string ItemAction { get; }
        string ItemName { get; }
        Sprite ItemSprite { get; } 
    }    
}

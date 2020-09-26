using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    interface IInteractableObject
    {
        Collider2D Collider2D { get; set; }

    }
}

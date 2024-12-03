using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Actors
{
    internal interface IInteractable
    {
        void Interact(Actor actor);
    }
}

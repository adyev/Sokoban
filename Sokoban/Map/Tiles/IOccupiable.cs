﻿using Sokoban.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Map.Tiles
{
    internal interface IOccupiable
    {
        void Occupy(Actor occupand);
    }
}

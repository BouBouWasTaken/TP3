﻿using System.Collections.Generic;

namespace tp3_prog.Classes.Characters
{
    public class Classe
    {
        public string Name { get; set; }
        public string? Portrait { get; set; }
        public int AtkByLevel { get; set; }
        public int DefByLevel { get; set; }
        public int HpByLevel { get; set; }
        public int MpByLevel { get; set; }
        public List<Magic> Magics { get; set; } = new List<Magic>();

    }

}

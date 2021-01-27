using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Dodge
{
    public class Input
    {
        public Keys Left { get; set; }
        public Keys Right { get; set; }
        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Jump { get; set; }
        public Keys Shoot { get; set; }
        public Keys Cheat { get; set; }
    }
}

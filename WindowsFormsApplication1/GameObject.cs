using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace ModTool
{
    class GameObject
    {
        public Vector2 _pos;
        public virtual void SetPosition(Vector2 pos)
        {
            _pos = pos;
        }

        public virtual void Draw(float gameTime) { }
    }
}

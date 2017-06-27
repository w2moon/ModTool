using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModTool
{
    class Sprite : GameObject
    {
        GraphicsDevice _gd;
        Texture2D _tex;
        SpriteBatch _sb;
        
        public Sprite(GraphicsDevice gd,string filename)
        {
            _gd = gd;
            _sb = new SpriteBatch(_gd);
            using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                _tex = Texture2D.FromStream(_gd, fileStream);
            }
        }
      

        public override void Draw(float gameTime) {
            _sb.Begin();
            _sb.Draw(_tex, _pos, Color.White);
            _sb.End();
        }
    }
}

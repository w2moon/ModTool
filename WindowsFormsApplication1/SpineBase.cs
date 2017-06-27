using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModTool
{
    class SpineBase : GameObject
    {
        SkeletonMeshRenderer skeletonRenderer;
        Skeleton skeleton;
        GraphicsDevice _gd;
        AnimationState state;
        public SpineBase(GraphicsDevice gd, string filename)
        {
            _gd = gd;

            skeletonRenderer = new SkeletonMeshRenderer(_gd);
            //skeletonRenderer.PremultipliedAlpha = true;

            string atlasFile = filename.Replace(".json",".atlas");
            Atlas atlas = new Atlas(atlasFile, new XnaTextureLoader(_gd));

            SkeletonJson json = new SkeletonJson(atlas);
            SkeletonData skeletonData = json.ReadSkeletonData(filename);

           skeleton = new Skeleton(skeletonData);

            AnimationStateData stateData = new AnimationStateData(skeleton.Data);
            state = new AnimationState(stateData);
            
        }
        public void Play(string animName,bool loop)
        {
            state.SetAnimation(0, animName, loop);
        }

        public override void SetPosition(Vector2 pos)
        {
            _pos = pos;
            skeleton.X = pos.X;
            skeleton.Y = pos.Y;
        }
        public override void Draw(float gameTime)
        {

            state.Update(gameTime);
            state.Apply(skeleton);
            skeleton.UpdateWorldTransform();
            skeletonRenderer.Begin();
            skeletonRenderer.Draw(skeleton);
            skeletonRenderer.End();

        }
    }
}

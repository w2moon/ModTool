#region File Description
//-----------------------------------------------------------------------------
// SpinningTriangleControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ModTool;
#endregion

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to draw animating
    /// 3D graphics inside a WinForms application. It hooks the Application.Idle
    /// event, using this to invalidate the control, which will cause the animation
    /// to constantly redraw.
    /// </summary>
    class SpinningTriangleControl : GraphicsDeviceControl
    {
        BasicEffect effect;
        Stopwatch timer;
        List<GameObject> objs = new List<GameObject>();
        public delegate void InitEventHandler(object sender);
        public event InitEventHandler initHandler;

        public void AddObject(GameObject obj)
        {
            objs.Add(obj);
        }

        public void DeleteObject(GameObject obj)
        {
            objs.Remove(obj);
        }

        public void Clear()
        {
            
            objs.Clear();
        }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            
            // Create our effect.
            effect = new BasicEffect(GraphicsDevice);

            effect.VertexColorEnabled = true;

            // Start the animation timer.
            timer = Stopwatch.StartNew();

            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };

            if (initHandler != null)
            {
                initHandler(this);
            }
            
        }


        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Spin the triangle according to how much time has passed.
            float time = (float)timer.Elapsed.TotalSeconds;

          
            
            /*
            effect.World = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll);

            effect.View = Matrix.CreateLookAt(new Vector3(0, 0, -5),
                                              Vector3.Zero, Vector3.Up);

            effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 1, 10);
            */
            effect.Projection = Matrix.CreateOrthographic(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 1, -1);
            // Set renderstates.
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            // Draw the triangle.
            effect.CurrentTechnique.Passes[0].Apply();
            for(int i = 0; i < objs.Count; ++i)
            {
                objs[i].Draw(time);
            }
            
        }
    }
}

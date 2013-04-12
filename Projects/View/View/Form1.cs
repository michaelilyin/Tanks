using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
using TanksInterfaces;
using TanksInterfaces.Attributes;

namespace View
{
    public partial class Form1 : Form, IView
    {
        private IController gameController = null;
        private Bitmap buffer;
        private Graphics gr;
        public Form1()
        {
            InitializeComponent();
            LoadEngine();
            gameController.Initialize();
            LoadResources();
            buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(buffer);
        }

        private void LoadResources()
        {
            Resources.Load();
        }

        private void LoadEngine()
        {
            string dir = System.IO.Directory.GetCurrentDirectory();
            dir += "\\Engine";
            string[] files = System.IO.Directory.GetFiles(dir, "*.dll");
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetCustomAttribute(typeof(GameControllerAttribute)) != null)
                    {
                        if (gameController == null)
                            gameController = (IController)Activator.CreateInstance(type, new object[] { this });
                        else
                            throw new Exception("Engine was created!");
                    }
                }
            }
            //gameController = new Controller(this);
        }

        public void Draw(List<ITank> tanks, List<IPhysicalObject> objects, List<Bullet> bullets)
        {
            gr.Clear(Color.Black);
            foreach (var physicalObject in objects)
            {
                gr.DrawImage(Resources.Objects[physicalObject.Type], 
                    physicalObject.Position.X - physicalObject.Size/2,
                    buffer.Height - (physicalObject.Position.Y - physicalObject.Size / 2) - physicalObject.Size, 
                    physicalObject.Size, physicalObject.Size);
            }
            foreach (var tank in tanks)
            {
                if (tank.Direction != Vector.Stand)
                {
                    gr.DrawImage(Resources.Traks[tank.Tracks.Type][tank.Direction],
                    tank.Position.X - tank.Size / 2,
                    buffer.Height - (tank.Position.Y - tank.Size / 2) - tank.Size,
                    tank.Size, tank.Size);
                    gr.DrawImage(Resources.Bodies[tank.Body.Type][tank.Direction],
                    tank.Position.X - tank.Size / 2,
                    buffer.Height - (tank.Position.Y - tank.Size / 2) - tank.Size,
                    tank.Size, tank.Size);
                    gr.DrawImage(Resources.Guns[tank.Gun.Type][tank.Direction],
                    tank.Position.X - tank.Size / 2,
                    buffer.Height - (tank.Position.Y - tank.Size / 2) - tank.Size,
                    tank.Size, tank.Size);
                }
                foreach (var bullet in bullets)
                {
                    gr.DrawImage(Resources.Bullets[bullet.Type][bullet.Direction],
                        bullet.Position.X - bullet.Size / 2,
                        buffer.Height - (bullet.Position.Y - bullet.Size / 2) - bullet.Size,
                        bullet.Size, bullet.Size);
                }
                //gr.DrawImage(Resources.Tanks[tank.Direction],
                //    tank.Position.X - tank.Size / 2,
                //    buffer.Height - (tank.Position.Y - tank.Size / 2) - tank.Size,
                //    tank.Size, tank.Size);
            }
            pictureBox1.Image = buffer;
        }

        #region Keys

        public int GetKey()
        {
            if (keys.Count > 0) return keys[keys.Count - 1];
            else return -1;
        }

        //private int _currentKey = -1;
        //private int _prevKey = -1;
        private List<int> keys = new List<int>();

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //_currentKey = e.KeyValue;
            if (!keys.Contains(e.KeyValue)) keys.Add(e.KeyValue);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //_currentKey = -1;
            keys.Remove(e.KeyValue);
        }

        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            gameController.Strat();
        }
    }
}

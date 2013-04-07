﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        public void Draw(List<ITank> tanks, List<IPhysicalObject> objects)
        {
            gr.Clear(Color.Black);
            foreach (var physicalObject in objects)
            {
                gr.DrawImage(Resources.Objects[physicalObject.Type], 
                    physicalObject.Position.X - physicalObject.Size/2,
                    buffer.Height - (physicalObject.Position.Y - physicalObject.Size / 2) - physicalObject.Size, 
                    physicalObject.Size, physicalObject.Size);
            }
            pictureBox1.Image = buffer;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            gameController.Strat();
        }
    }
}
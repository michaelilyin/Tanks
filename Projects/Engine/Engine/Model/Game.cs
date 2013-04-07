using System;
using System.Collections.Generic;
using System.Threading;
using TanksInterfaces;

namespace Engine.Model
{
    public class DrawEventArgs : EventArgs
    {
        public List<ITank> Tanks;
        public List<IPhysicalObject> Objects;
        public DrawEventArgs(List<ITank> tanks, List<IPhysicalObject> objects)
        {
            Tanks = tanks;
            Objects = objects;
        }
    }

    public delegate void DrawEvent(object sender, DrawEventArgs e);

    public class Game
    {
        #region Singletone

        private Game()
        {
        }

        private static readonly Game _instance = new Game();
        public static Game Instance
        {
            get { return _instance; }
        }

        #endregion

        public event DrawEvent Draw;
        private void _draw()
        {
            if (Draw != null)
                Draw(this, new DrawEventArgs(_currentLevel.Tanks, _currentLevel.Objects));
        }

        private System.Timers.Timer timer;
        public void Initialize()
        {
            timer = new System.Timers.Timer(28) {Enabled = false};
            timer.Elapsed += timer_Elapsed;
            _currentLevel = new Level();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            Update();
            _draw();
            timer.Start();
        }

        private ILevel _currentLevel;

        private void Update()
        {
            _currentLevel.Update();
        }

        public void Start()
        {
            _currentLevel.Load(1);
            timer.Start();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Continue()
        {
            throw new NotImplementedException();
        }
    }
}

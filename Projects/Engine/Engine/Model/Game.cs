using System;
using TanksInterfaces;

namespace Engine.Model
{
    public class DrawEventArgs : EventArgs
    {
        public DrawEventArgs()
        {

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
                Draw(this, new DrawEventArgs());
        }
        public void Initialize()
        {
            _currentLevel = new Level();
        }

        private ILevel _currentLevel;

        private void Update()
        {
            _currentLevel.Update();
        }

        public void Start()
        {
            _currentLevel.Load(1);
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

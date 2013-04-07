using System;
using Engine.Model;
using TanksInterfaces;
using TanksInterfaces.Attributes;

namespace Engine
{
    [GameController()]
    public class Controller : IController
    {
        private readonly IView _view;

        public Controller(IView view)
        {
            _view = view;
        }

        private void Game_Draw(object sender, DrawEventArgs e)
        {
            _view.Draw(e.Tanks, e.Objects);
        }

        public static int GetKey()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            Game.Instance.Initialize();
            Game.Instance.Draw += Game_Draw;
        }

        public void Continue()
        {
            Game.Instance.Continue();
        }

        public void Strat()
        {
            Game.Instance.Start();
        }

        public void Pause()
        {
            Game.Instance.Pause();
        }
    }
}

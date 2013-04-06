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
            Game.Instance.Initialize();
            Game.Instance.Draw += Game_Draw;
        }

        private void Game_Draw(object sender, DrawEventArgs e)
        {
            _view.Draw();
        }

        public static int GetKey()
        {
            throw new NotImplementedException();
        }
    }
}

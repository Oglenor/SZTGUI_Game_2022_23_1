using Core.Interfaces;
using Core.Models;
using Core.Models.GameElements;
using Render.Implementations;
using Render.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LordOfTheCards.Controls
{
    public class LordOfTheCardsControl : FrameworkElement
    {
        IGameRenderer gameRenderer;      

        private static LordOfTheCardsControl instance = null;

        private LordOfTheCardsControl()
        {
            Loaded += LordOfTheCardsControl_Loaded;
        }

        public static LordOfTheCardsControl GetInstance()
        {
            if (instance == null)
            {
                return new LordOfTheCardsControl();
            }
            else
            {
                return instance;
            }
        }

        private void LordOfTheCardsControl_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("+++");
            var window = Window.GetWindow(this);

            if (window != null)
            {

                //MessageBox.Show("+++");
                IGameModel gameModel = new GameModel();

                gameModel.Maps = new Dictionary<string, Core.Models.GameElements.Map>();

                Map m = new Map("defaultmap", 5, 5);

                m.Tiles = new List<Tile>();

                for (int i = 0; i < m.RowCapacity * m.ColumnCapacity; i++)
                {
                    m.Tiles.ToList().Add(new Tile(i + 50, i + 50, i % 2 == 0));
                }

                gameModel.Maps.Add("defaultmap", m);

                gameRenderer = new GameRenderer(800, 800, gameModel);

                InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameRenderer != null)
            {
                string msg = gameRenderer.GameModel.Maps.GetValueOrDefault("defaultmap").Name;
                //MessageBox.Show(msg);

                drawingContext.DrawDrawing(gameRenderer.GetDrawing());
            }

        }
    }
}

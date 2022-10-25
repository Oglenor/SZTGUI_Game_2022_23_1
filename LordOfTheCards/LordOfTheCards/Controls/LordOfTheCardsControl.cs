using Core.Interfaces;
using Core.Models;
using Core.Models.Enums;
using Core.Models.GameElements;
using Core.Settings;
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
            var window = Window.GetWindow(this);

            if (window != null)
            {
                IGameSettings gameSettings = GameSettings.Instance;
                IGameModel gameModel = new GameModel();

                gameModel.Maps = new Dictionary<string, Map>();
                Map m = new Map(gameSettings.DefaultMapName, 5, 5);

                List<Tile> tiles = new List<Tile>();

                for (int x = 0, y = 0, k = 0; k < m.RowCapacity * m.ColumnCapacity; k++)
                {
                    var condition = k % 5 == 0;
                    y = condition ? ++y : y;
                    x = condition ? 0 : ++x;

                    Tile t = new Tile(x * gameSettings.TileWidth, y * gameSettings.TileHeight, k % 2 == 0);

                    t.Width = gameSettings.TileWidth;
                    t.Height = gameSettings.TileHeight;

                    if (k % 2 == 0) t.type = BitMapType.floor;
                    else t.type = BitMapType.wall;

                    tiles.Add(t);                                       
                }

                m.Tiles = tiles;
                gameModel.Maps.Add(m.Name, m);                
                gameRenderer = new GameRenderer(gameModel, gameSettings);

                InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameRenderer != null && gameRenderer.GameModel != null)
            {

                Map m = gameRenderer.GameModel.Maps.GetValueOrDefault(gameRenderer.GameSettings.DefaultMapName);
                IEnumerable<StaticGameItem> t = null;
                if (m != null)
                    t = m.Tiles;


                drawingContext.DrawDrawing(gameRenderer.GetDrawing(t));
                ;
            }
        }
    }
}

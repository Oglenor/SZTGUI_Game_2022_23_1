﻿using Core.Interfaces;
using Core.Models;
using Core.Models.Enums;
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
            var window = Window.GetWindow(this);

            if (window != null)
            {

                int tileWidth = 32;
                int tileHeight = 32;

                IGameModel gameModel = new GameModel();

                gameModel.Maps = new Dictionary<string, Core.Models.GameElements.Map>();

                Map m = new Map("defaultmap", 5, 5);

                List<Tile> tiles = new List<Tile>();

                for (int x = 0, y = 0, k = 0; k < m.RowCapacity * m.ColumnCapacity; k++)
                {
                    var condition = k % 5 == 0;
                    y = condition ? ++y : y;
                    x = condition ? 0 : ++x;

                    Tile t = new Tile(x * tileWidth, y * tileHeight, k % 2 == 0);

                    if (k % 2 == 0) t.type = BitMapType.floor;
                    else t.type = BitMapType.wall;

                    tiles.Add(t);                                       
                }

                m.Tiles = tiles;

                gameModel.Maps.Add("defaultmap", m);

                gameRenderer = new GameRenderer(800, 800, gameModel);

                InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameRenderer != null)
            {
                drawingContext.DrawDrawing(gameRenderer.GetDrawing());
            }
        }
    }
}

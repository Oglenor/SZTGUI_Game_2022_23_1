using Core.Interfaces;
using Core.Models.Enums;
using Core.Models.GameElements;
using Render.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Render.Implementations
{
    public class GameRenderer : IGameRenderer
    {

        private double width;
        private double height;
        readonly Dictionary<string, Lazy<ImageBrush>> itemBrushes;

        private IGameModel gameModel;
        public IGameModel GameModel { get { return gameModel; } set { gameModel = value; } }

        // TODO load from IGameSettings
        private int tileWidth = 32;
        private int tileHeight = 32;
        private const string PATH_BASE = "Resources/Images/";
        private const string TEST_MAP_NAME = "defaultmap";

        public GameRenderer(double width, double height, IGameModel gameModel)
        {
            this.width = width;
            this.height = height;            
            this.gameModel = gameModel;
            itemBrushes = new Dictionary<string, Lazy<ImageBrush>>();           
            LoadBrushes();
        }

        public Drawing GetDrawing()
        {
            var dg = new DrawingGroup();
            dg.Children.Add(DrawGameItems());
            return dg;
        }

        #region Init_Brushes
        private void LoadBrushes()
        {
            var brushNames = Enum.GetNames(typeof(BitMapType));
            foreach (var item in brushNames)
            {
                itemBrushes.Add(item, new Lazy<ImageBrush>(() => LoadBrush($"{PATH_BASE}{item}.png")));
            }
        }

        private ImageBrush LoadBrush(string name)
        {
            var resultBrush = new ImageBrush(new BitmapImage(new Uri(name, UriKind.Relative)));
            resultBrush.TileMode = TileMode.Tile;
            resultBrush.Viewport = new Rect(0, 0, tileWidth, tileHeight);
            resultBrush.Stretch = Stretch.Uniform;
            resultBrush.ViewportUnits = BrushMappingMode.Absolute;
            return resultBrush;
        }
        #endregion

        #region Draw_Items
        private Drawing DrawGameItems()
        {
            var dg = new DrawingGroup();
            List<Tile> itemList = gameModel.Maps.GetValueOrDefault(TEST_MAP_NAME).Tiles.ToList();           
            foreach (var item in itemList)
            {                
                dg.Children.Add(GetGeometryDrawing(item));                   
            }
            return dg;
        }

        private GeometryDrawing GetGeometryDrawing(Tile tile)
        {
            return new GeometryDrawing(
                GetBrush(tile.type.ToString()),
                null,
                GetRectangleGeometry(tile.X, tile.Y));
        }

        private Geometry GetRectangleGeometry(double x, double y)
        {
            return new RectangleGeometry(new Rect(x, y, tileWidth, tileHeight));
        }

        private ImageBrush GetBrush(string brusName)
        {
            return itemBrushes.GetValueOrDefault(brusName).Value;
        }
        #endregion
    }
}
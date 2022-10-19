using Core.Interfaces;
using Core.Models.GameElements;
using Render.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Render.Implementations
{
    public class GameRenderer : IGameRenderer
    {

        private double width;
        private double height;
        readonly Dictionary<string, Lazy<ImageBrush>> itemBrushes;

        private IGameModel gameModel;
        public IGameModel GameModel { get { return gameModel; } set { gameModel = value; } }

        public GameRenderer(double width, double height, IGameModel gameModel)
        {
            this.width = width;
            this.height = height;            
            this.gameModel = gameModel;

            string wallPath = $"Resources/Images/wall.png";
            string floorPath = $"Resources/Images/floor.png";

            itemBrushes = new Dictionary<string, Lazy<ImageBrush>>();
            itemBrushes.Add("wall", new Lazy<ImageBrush>(() => LoadBrush(wallPath)));
            itemBrushes.Add("floor", new Lazy<ImageBrush>(() => LoadBrush(floorPath)));

        }

        private ImageBrush LoadBrush(string wallPath)
        {
            var resultBrush = new ImageBrush(new BitmapImage(new Uri(wallPath, UriKind.Relative)));
            resultBrush.TileMode = TileMode.Tile;
            resultBrush.Viewport = new Rect(0, 0, 50, 50);
            resultBrush.Stretch = Stretch.Uniform;
            resultBrush.ViewportUnits = BrushMappingMode.Absolute;
            return resultBrush;
        }

        public Drawing GetDrawing()
        {
            var dg = new DrawingGroup();
            dg.Children.Add(DrawGameItems());
            return dg;
        }

        private Drawing DrawGameItems()
        {
            var dg = new DrawingGroup();

            List<Tile> itemList = gameModel.Maps.GetValueOrDefault("defaultmap").Tiles.ToList();

           
            foreach (var item in itemList)
            {                
                if (item.IsSolid)
                {
                    dg.Children.Add(new GeometryDrawing(
                    GetBrush("wall"),
                    null,
                    GetRectangleGeometry(item.X, item.Y, 50, 50)
                    ));
                }
                else
                {
                    dg.Children.Add(new GeometryDrawing(
                    GetBrush("floor"),
                    null,
                    GetRectangleGeometry(item.X, item.Y, 50, 50)
                    ));
                }
                
            }

            return dg;
        }

        private Geometry GetRectangleGeometry(double x, double y, double width, double height)
        {
            return new RectangleGeometry(new Rect(x, y, width, height));
        }

        //Todo modify to enum type
        private ImageBrush GetBrush(string brusName)
        {
            return itemBrushes.GetValueOrDefault(brusName).Value;
        }
    }
}

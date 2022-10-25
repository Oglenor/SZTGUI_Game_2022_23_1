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
        readonly Dictionary<string, Lazy<ImageBrush>> itemBrushes;
        private IGameModel gameModel;
        private IGameSettings gameSettings;
        public IGameModel GameModel { get => gameModel; set => gameModel = value; }
        public IGameSettings GameSettings { get => gameSettings; set => gameSettings = value; }      

        public GameRenderer(IGameModel gameModel, IGameSettings gameSettings)
        {
            this.gameModel = gameModel;
            this.gameSettings = gameSettings;
            itemBrushes = new Dictionary<string, Lazy<ImageBrush>>();           
            LoadBrushes();
        }



        public Drawing GetDrawing(IEnumerable<StaticGameItem> collection)
        {
            var dg = new DrawingGroup();
            dg.Children.Add(DrawGameItems(collection));
            return dg;
        }

        #region Init_Brushes
        private void LoadBrushes()
        {
            var brushNames = Enum.GetNames(typeof(BitMapType));
            foreach (var item in brushNames)
            {
                itemBrushes.Add(item, new Lazy<ImageBrush>(() => LoadBrush($"{gameSettings.ResourcesPath}{item}.png")));
            }
        }

        private ImageBrush LoadBrush(string name)
        {
            var resultBrush = new ImageBrush(new BitmapImage(new Uri(name, UriKind.Relative)));
            resultBrush.TileMode = TileMode.Tile;
            resultBrush.Viewport = new Rect(0, 0, gameSettings.TileWidth, gameSettings.TileHeight);
            resultBrush.Stretch = Stretch.Uniform;
            resultBrush.ViewportUnits = BrushMappingMode.Absolute;
            return resultBrush;
        }
        #endregion

        #region Draw_Items
        private Drawing DrawGameItems(IEnumerable<StaticGameItem> collection)
        {
            var dg = new DrawingGroup();
            collection.ToList().ForEach(x => dg.Children.Add(GetGeometryDrawing(x)));
            return dg;
        }

        private GeometryDrawing GetGeometryDrawing(StaticGameItem item)
        {
            return new GeometryDrawing(
                GetBrush(item.type.ToString()),
                null,
                GetRectangleGeometry(item));
        }

        private Geometry GetRectangleGeometry(StaticGameItem item)
        {
            return new RectangleGeometry(new Rect(item.X, item.Y, item.Width, item.Height));
        }

        private ImageBrush GetBrush(string brusName)
        {
            return GetItemFromMap(brusName, itemBrushes).Value;            
        }

        private V GetItemFromMap<K,V>(K key, IDictionary<K,V> map)
        {
            V value;
            if (map.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                throw new KeyNotFoundException($"Key: {key}, was not found!");
            }
        }
        #endregion
    }
}
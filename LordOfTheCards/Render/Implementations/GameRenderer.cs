using Core.Interfaces;
using Core.Models.Enums;
using Core.Models.GameElements;
using Core.Settings;
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
        private readonly IGameSettings gameSettings;
        private readonly Dictionary<string, Lazy<ImageBrush>> itemBrushes;
        private DrawingGroup drawingGroup;

        public GameRenderer()
        {
            gameSettings = GameSettings.Instance;
            itemBrushes = new Dictionary<string, Lazy<ImageBrush>>();
            LoadBrushes();
        }

        public Drawing GetDrawing(IEnumerable<StaticGameItem> collection)
        {
            drawingGroup = new DrawingGroup();

            collection.ToList()
                .Select(gameItem => new GeometryDrawing(GetItemFromMap(gameItem.type.ToString(), itemBrushes).Value, null, new RectangleGeometry(new Rect(gameItem.X, gameItem.Y, gameItem.Width, gameItem.Height))))
                .ToList()
                .ForEach(x => drawingGroup.Children.Add(x));

            return drawingGroup;
        }

        private void LoadBrushes()
        {
            Enum.GetNames(typeof(BitMapType))
                .ToList()
                .ForEach(x => itemBrushes.Add(x, new Lazy<ImageBrush>(() => LoadBrush($"{gameSettings.ResourcesPath}{x}.png"))));
        }

        private ImageBrush LoadBrush(string name)
        {
            var bitMap = new BitmapImage(new Uri(name, UriKind.Relative));           
            var resultBrush = new ImageBrush(bitMap);
            resultBrush.TileMode = TileMode.Tile;
            resultBrush.Viewport = new Rect(0, 0, bitMap.Width, bitMap.Height);
            resultBrush.Stretch = Stretch.Uniform;
            resultBrush.ViewportUnits = BrushMappingMode.Absolute;
            return resultBrush;
        }

        private V GetItemFromMap<K,V>(K key, IDictionary<K,V> map)
        {
            if (map.TryGetValue(key, out V? value))
            {
                return value;
            }
            else
            {
                throw new KeyNotFoundException($"Key: {key}, was not found!");
            }
        }
    }
}
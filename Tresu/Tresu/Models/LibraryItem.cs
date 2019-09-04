using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tresu.Models
{
    public class LibraryItem
    {
        public string Name { get; set; }

        public BitmapImage Icon { get; set; }

        public string Description { get; set; }
    }
}

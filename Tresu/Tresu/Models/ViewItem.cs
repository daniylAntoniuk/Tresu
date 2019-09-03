using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tresu.Models
{
   public class ViewItem
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public ViewItem()
        {
           
        }
        public ViewItem( ViewItem view)
        {
            Id = view.Id;
            PlayerName = view.PlayerName;
        }
    }
}

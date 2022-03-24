using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helperland.ViewModels
{
    public class BlockCustomerData
    {

        public User user { get; set; }

        public FavoriteAndBlocked favoriteAndBlocked { get; set; }

    }
}
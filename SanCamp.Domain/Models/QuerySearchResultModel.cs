using System;
using System.Collections.Generic;
using System.Text;
using static SanCamp.Domain.Models.HotelDetailsModel;

namespace SanCamp.Domain.Models
{
    public class QuerySearchResultModel
    {
        public List<City> Cities { get; set; } = new List<City>();
        public QueryModel QueryModel { get; set; }

    }

}

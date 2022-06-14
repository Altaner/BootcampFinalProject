using System;
using System.Collections.Generic;
using System.Text;

namespace SanCamp.Domain.Models
{


    public class ArrivalLocation
    {
        public string Id { get; set; }
        public int Type { get; set; } = 2;
    }

    public class RoomCriterion
    {
        public int Adult { get; set; } = 2;
        public List<int> ChildAges { get; set; }// = new List<int>() { 2, 5 };

    }

    public class PriceSearchModel
    {
        public bool CheckAllotment { get; set; } = true;
        public bool CheckStopSale { get; set; } = true;
        public bool GetOnlyDiscountedPrice { get; set; } = false;
        public bool GetOnlyBestOffers { get; set; } = true;
        public int ProductType { get; set; } = 2;
        public List<ArrivalLocation> ArrivalLocations { get; set; }
        public List<RoomCriterion> RoomCriteria { get; set; }
        public string Nationality { get; set; } = "DE";
        public string CheckIn { get; set; } = "2022-10-17";
        public int Night { get; set; } = 7;
        public string Currency { get; set; } = "EUR";
        public string Culture { get; set; } = "en-US";
    }



}

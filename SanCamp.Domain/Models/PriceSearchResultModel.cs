using System;
using System.Collections.Generic;
using System.Text;

namespace SanCamp.Domain.Models
{
    public class PriceSearchResultModel
    {
        public class Badge
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class BoardGroup
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class Body
        {
            public string SearchId { get; set; }
            public DateTime ExpiresOn { get; set; }
            public List<Hotel> Hotels { get; set; }
            public Details Details { get; set; }
        }

        public class CancellationPolicy
        {
            public DateTime DueDate { get; set; }
            public Price Price { get; set; }
            public int Provider { get; set; }
        }

        public class City
        {
            public string Name { get; set; }
            public string CountryId { get; set; }
            public int Provider { get; set; }
            public bool IsTopRegion { get; set; }
            public string Id { get; set; }
        }

        public class Country
        {
            public string InternationalCode { get; set; }
            public string Name { get; set; }
            public int Provider { get; set; }
            public bool IsTopRegion { get; set; }
        }

        public class Description
        {
            public string Text { get; set; }
        }

        public class Details
        {
            public bool EnablePaging { get; set; }
        }

        public class Facility
        {
            public bool IsPriced { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class Geolocation
        {
            public string Longitude { get; set; }
            public string Latitude { get; set; }
        }

        public class GiataInfo
        {
            public string HotelId { get; set; }
            public string DestinationId { get; set; }
        }

        public class Header
        {
            public string RequestId { get; set; }
            public bool Success { get; set; }
            public DateTime ResponseTime { get; set; }
            public List<Messages> Messages { get; set; }
        }

        public class Hotel
        {
            public Geolocation Geolocation { get; set; }
            public float Stars { get; set; }
            public double Rating { get; set; }
            public List<Theme> Themes { get; set; }
            public List<Facility> Facilities { get; set; }
            public Location Location { get; set; }
            public Country Country { get; set; }
            public City City { get; set; }
            public GiataInfo GiataInfo { get; set; }
            public List<Offer> Offers { get; set; }
            public string Address { get; set; }
            public List<BoardGroup> BoardGroups { get; set; }
            public List<Badge> Badges { get; set; }
            public HotelCategory HotelCategory { get; set; }
            public bool HasThirdPartyOwnOffer { get; set; }
            public int Provider { get; set; }
            public string Thumbnail { get; set; }
            public string ThumbnailFull { get; set; }
            public Description Description { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class HotelCategory
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string Code { get; set; }
        }

        public class Location
        {
            public string Name { get; set; }
            public string CountryId { get; set; }
            public int Provider { get; set; }
            public bool IsTopRegion { get; set; }
            public string Id { get; set; }
        }

        public class Messages
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public int MessageType { get; set; }
            public string Message { get; set; }
        }

        public class Offer
        {
            public int Night { get; set; }
            public bool IsAvailable { get; set; }
            public int Availability { get; set; }
            public List<Room> Rooms { get; set; }
            public bool IsRefundable { get; set; }
            public List<CancellationPolicy> CancellationPolicies { get; set; }
            public DateTime ExpiresOn { get; set; }
            public string OfferId { get; set; }
            public DateTime CheckIn { get; set; }
            public Price Price { get; set; }
            public int Provider { get; set; }
        }

        public class Price
        {
            public double Amount { get; set; }
            public string Currency { get; set; }
        }

        public class Room
        {
            public string RoomId { get; set; }
            public string RoomName { get; set; }
            public string BoardId { get; set; }
            public string BoardName { get; set; }
            public List<BoardGroup> BoardGroups { get; set; }
            public int StopSaleGuaranteed { get; set; }
            public int StopSaleStandart { get; set; }
            public List<Traveller> Travellers { get; set; }
        }

        public class Root
        {
            public Body Body { get; set; }
            public Header Header { get; set; }
        }

        public class Theme
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class Traveller
        {
            public int Type { get; set; }
            public int Age { get; set; }
            public string Nationality { get; set; }
            public int MinAge { get; set; }
            public int MaxAge { get; set; }
        }


    }
}
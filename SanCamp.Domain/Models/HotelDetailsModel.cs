using System;
using System.Collections.Generic;

namespace SanCamp.Domain.Models
{
    public class HotelDetailsModel
    {
        public Body Body { get; set; }
        public Header Header { get; set; }
    }
    public class Body
    {
        public List<Item> Items { get; set; }
    }

    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


    public class Item
    {
        public int Type { get; set; }
        public Geolocation Geolocation { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public int Provider { get; set; }
        public int HotelCount { get; set; }
        public Hotel Hotel { get; set; }
    }

    public class Geolocation
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }

    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class State
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    

    public class Hotel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Header
    {
        public string RequestId { get; set; }
        public bool Success { get; set; }
        public DateTime ResponseTime { get; set; }
        public Message[] Messages { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int MessageType { get; set; }
        public string message { get; set; }
    }

}



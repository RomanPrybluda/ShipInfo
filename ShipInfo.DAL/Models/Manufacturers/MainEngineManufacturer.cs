﻿namespace ShipInfo.DAL
{
    public class MainEngineManufacturer
    {
        public Guid Id { get; set; }

        public string? MainEngineManufacturerName { get; set; }

        public ICollection<MainEngine>? MainEngines { get; set; }

    }
}
﻿using Bogus;
using ShipInfo.DAL;
using ShipInfo.Domain.Entities;

namespace ShipInfo.Domain
{
    public class OwnerInitializer
    {
        private readonly ShipInfoDbContext _context;

        public OwnerInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeOwners()
        {
            var faker = new Faker();

            var existingOwnersCount = _context.Owners.Count();

            if (existingOwnersCount < 50)
            {
                for (int i = 0; i < 50 - existingOwnersCount; i++)
                {
                    var maxLength = 30;
                    var ownerName = GenerateEnglishCompanyName(faker);
                    var address = faker.Address.FullAddress();
                    var phoneNumber = faker.Phone.PhoneNumber("+1##########");
                    var email = faker.Internet.Email();

                    var owner = new Owner
                    {
                        OwnerName = ownerName.Length <= maxLength ? ownerName : ownerName.Substring(0, maxLength),
                        OwnerAddress = address,
                        OwnerEmail = email,
                        OwnerPhone = phoneNumber
                    };

                    _context.Owners.Add(owner);
                }

                _context.SaveChanges();
            }
        }

        private string GenerateEnglishCompanyName(Faker faker)
        {
            var random = new Random();
            int index = random.Next(EnglishCompanyNames.Length);
            return EnglishCompanyNames[index];
        }

        private string[] EnglishCompanyNames = new string[]
        {
                "Ocean Trade Lines",
                "Global Maritime Group",
                "Harbor Shipping Co.",
                "Pacific Nautical Services",
                "Maritime Ventures Inc.",
                "Coastal Navigation Ltd.",
                "Bluewave Shipping",
                "Seafarers Logistics",
                "Cruise Masters Ltd.",
                "Starboard Shipping Co.",
                "Nautical Express",
                "Marine Transport Solutions",
                "Golden Anchor Shipping",
                "Majestic Marine Group",
                "CargoNet Shipping",
                "SeaLink Freight Services",
                "Aqua Maritime Ltd.",
                "North Star Navigation",
                "Harmony Shipping Lines",
                "WaveCrest Shipping Co.",
                "Marine Dynamics Inc.",
                "Horizon Shipping Group",
                "OceanVoyage Logistics",
                "Nautical Horizon Ltd.",
                "Seafarer Express",
                "MarineWave Services",
                "Sailor's Choice Shipping",
                "Windward Maritime Solutions",
                "Mediterranean Cruise Lines",
                "TransGlobal Navigation",
                "TideRider Shipping Co.",
                "Alliance Marine Group",
                "Sunset Logistics Inc.",
                "Bluewater Shipping",
                "Oceanic Express Lines",
                "Captain's Cargo Services",
                "Deep Blue Ventures",
                "SailAway Shipping Co.",
                "Maritime Links Inc.",
                "Seaborne Navigation",
                "Endless Sea Logistics",
                "BlueMarine Group",
                "Atlantic Shipping Co.",
                "MarineVoyage Solutions",
                "Great Lakes Navigation",
                "Pacific Pearl Shipping",
                "Coastwise Shipping Lines",
                "Sailor's Delight Logistics",
                "TradeWinds Shipping",
                "Majestic Marine Ventures",
        };

    }
}
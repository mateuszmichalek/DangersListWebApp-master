using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DangersListApp.Models
{
    public class Zgloszenie
    {
        public string siebelEventId { get; set; }
        [DisplayName("Źródło zgłoszenia")]
        public string deviceType { get; set; }
        [DisplayName("Ulica")]
        public string street { get; set; }
        public string street2 { get; set; }
        [DisplayName("Dzielnica")]
        public string district { get; set; }
        [DisplayName("Miasto")]
        public string city { get; set; }
        public string aparmentNumber { get; set; }
        [DisplayName("Kategoria")]
        public string category { get; set; }
        [DisplayName("Podkategoria")]
        public string subcategory { get; set; }
        public string eventName { get; set; }
        [DisplayName("Data zgłoszenia")]
        public long createDate { get; set; }
        public string notificationNumber { get; set; }
        public string xCoordWGS84 { get; set; }
        public string yCoordWGS84 { get; set; }
        public string xCoordOracle { get; set; }
        public string yCoordOracle { get; set; }
        [DisplayName("Typ zgłoszenia")]
        public string notificationType { get; set; }
        public List<Status> statuses { get; set; }
        [DisplayName("Źródło")]
        public string Source { get; set; }
        public string responseCode { get; set; }
        public string responseDesc { get; set; }
    }
}
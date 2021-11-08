using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrainMaster.Models
{
    public class PortFolioModel
    {
        public int ID { get; set; }
        [Required]
        public string StockName { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public DateTime Date { get; set; }

        
    }

    public class CombinedPortFolioModel
    {
        public PortFolioModel PortFolio { get; set; }
        public List<PortFolioModel> PortFolioList { get; set; }
    }

    public class StockDetail
    {
        public int ID;
        public string Name;
    };

}
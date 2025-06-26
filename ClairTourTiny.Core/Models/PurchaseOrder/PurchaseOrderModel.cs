using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClairTourTiny.Core.Models.PurchaseOrder
{
    public class PurchaseOrderModel
    {
        public int IdPurchaseOrder { get; set; }
        public int PONumber { get; set; }
        public string PODescription { get; set; }
        public string Currency { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}

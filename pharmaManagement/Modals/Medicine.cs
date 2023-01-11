using System;
namespace pharmaManagement.Modals
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string quantity { get; set; }
        public string batchId { get; set; }
        public int price { get; set; }
        public DateTime expiryDate { get; set; }
    }

}


using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbConnectWithCore
{
    [DataContract]
    public class Shop
    {
        [DataMember]
        public int shopId { get; set; }
        [DataMember]
        public string shopName { get; set; }
        [DataMember]
        public int? shopRate { get; set; }
        [DataMember]
        public List<Product> Products { get; set; }
        public ShopCustomer ShopCustomers { get; set; }
    }
}

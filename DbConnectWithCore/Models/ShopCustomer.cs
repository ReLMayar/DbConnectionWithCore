using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbConnectWithCore
{
    [DataContract]
    public class ShopCustomer
    {
        [DataMember]
        public int shopcustomerId { get; set; }
        [DataMember]
        public int shopId { get; set; }
        [DataMember]
        public int customerId { get; set; }
        public List<Shop> Shops { get; set; }
        public List<Customer> Customers { get; set; }
    }
}

using System.Runtime.Serialization;

namespace DbConnectWithCore
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int customerId { get; set; }
        [DataMember]
        public string fName { get; set; }
        [DataMember]
        public string lName { get; set; }
        [DataMember]
        public string customerEmail { get; set; }
        public ShopCustomer ShopCustomers { get; set; }
    }
}

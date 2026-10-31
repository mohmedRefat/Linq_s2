public class Customer
{
	public string CustomerID { get; set; } = "";
	public string CustomerName { get; set; } = "";
	public string Address { get; set; } = "";
	public string City { get; set; } = "";
	public string Region { get; set; } = "";
	public string PostalCode { get; set; } = "";
	public string Country { get; set; } = "";
	public string Phone { get; set; } = "";
	public Order[] Orders { get; set; } = Array.Empty<Order>();
}
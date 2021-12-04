using System;

public class Reservation
{
	public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime checkinDateTime { get; set; }
    public DateTime checkoutDateTime { get; set; }
    public string Room { get; set; }
    public int NumberOfPeople { get; set; }

    public string checkinDateTime => checkinDateTime.ToString("MM/dd/yyyy");
    public string checkoutDateTime => checkoutDateTime.ToString("MM/dd/yyyy");


}

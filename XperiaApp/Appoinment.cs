using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace XperiaApp.Models
{
   public class Appoinment
    {
        [PrimaryKey, AutoIncrement]
        public int AppointmentID { get; set; }
        public DateTime Appointment_Date { get; set; }
        public string Appointment_Status { get; set; }
    }
}

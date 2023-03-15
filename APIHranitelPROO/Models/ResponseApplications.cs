using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHranitelPROO.Models
{
    public class ResponseApplications
    {
        public ResponseApplications(Applications applications)
        {
            id = applications.id;
            DateRegistr = applications.DateRegistr;
            AppointmentId = applications.AppointmentId;
        }
        public int id { get; set; }
        public DateTime DateRegistr { get; set; }
        public int AppointmentId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainWebApplication1.Models
{
    public class elresult
    {
        public int id { get; set; }

        public int personid { get; set; }

        public string personname { get; set; }

        public int courseid { get; set; }

        public string coursedesc { get; set; }

        public int score { get; set; }

        public int maxscore { get; set; }

        public bool passfail { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetData.Models
{
    public class App_logs : CommonBaseModel
    {
        public string Method_Name { get; set; }
        public string Description { get; set; }

        public void Add()
        {           
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.App_logs.Add(this);
                    _db.SaveChanges();
                }
                
                catch (Exception ex)
                {
                    throw ex;
                }
            }         
           
        }
    }
}

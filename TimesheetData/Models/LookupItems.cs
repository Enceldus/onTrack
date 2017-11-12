using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetData.Models
{
   public class LookupItems : CommonBaseModel
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public void Add()
        {
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.LookupItems.Add(this);
                    _db.SaveChanges();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public static List<LookupItems> GetLookupItems()
        {
            List<LookupItems> _Items = new List<LookupItems>();
            try
            {
                using (TSModel _db = new TSModel())
                {
                    try
                    {
                        var _Data = from p in _db.LookupItems select p;
                        if (_Data != null && _Data.Count() > 0)
                        {
                            _Items = _Data.ToList();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                App_logs al = new App_logs { Description = ex.Message, Method_Name = System.Reflection.MethodBase.GetCurrentMethod().Name };
                al.Add();
            }
            return _Items;
        }
        public static List<LookupItems> Lookup(string Key_)
        {
            List <LookupItems> _Items = new List<LookupItems>();
            try
            {
                var _Data = LookupItems.GetLookupItems();
                if (_Data != null && _Data.Count() > 0)
                {                   
                        _Items = _Data.ToList();                   
                }
            }
            catch (Exception ex)
            {
                App_logs al = new App_logs { Description = ex.Message, Method_Name = System.Reflection.MethodBase.GetCurrentMethod().Name };
                al.Add();
            }
            return _Items;
        }
    }
}

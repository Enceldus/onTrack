using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetData.Models
{
   public class Projects : CommonBaseModel
    {
        [ForeignKey("Clients")]
        public long? Client_ID { get; set; }
        public string Project_Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndEnd { get; set; }
        public virtual Clients Clients { get; set; }
        public static List<Projects> GetAllProject()
        {
            List<Projects> _Items = new List<Projects>();
            try
            {
                using (TSModel _db = new TSModel())
                {
                    try
                    {
                        var _Data = from p in _db.Projects select p;
                        if (_Data != null && _Data.Count() > 0)
                        {
                            _Items = _Data.AsNoTracking().ToList();
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
        public static Projects Lookup(long ID_)
        {
            Projects _Items = new Projects();
            try
            {
                var _Data = Projects.GetAllProject();
                if (_Data != null && _Data.Count() > 0)
                {
                    var _Result = _Data.Where(x => x.Id == ID_);
                    if (_Result != null && _Data.Count() > 0)
                    {
                        _Items = _Result.FirstOrDefault();
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
        public static Projects Lookup(string Project_Name_,long Client_ID_)
        {
            Projects _Items = new Projects();
            try
            {
                var _Data = Projects.GetAllProject();
                if (_Data != null && _Data.Count() > 0)
                {
                    var _Result = _Data.Where(x => x.Project_Name == Project_Name_ && x.Client_ID==Client_ID_);
                    if (_Result != null && _Data.Count() > 0)
                    {
                        _Items = _Result.FirstOrDefault();
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
        public static List<Projects> LookupbyClientID(long Client_ID_)
        {
            List<Projects> _Items = new List<Projects>();
            try
            {
                var _Data = Projects.GetAllProject();
                if (_Data != null && _Data.Count() > 0)
                {
                    var _Result = _Data.Where(x => x.Client_ID == Client_ID_);
                    if (_Result != null && _Data.Count() > 0)
                    {
                        _Items = _Result.ToList();
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
        public bool Add(out bool DBException_)
        {
            bool _DBException = false;
            bool success = false;
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.Projects.Add(this);
                    _db.SaveChanges();
                    success = true;

                }
                catch (Exception ex)
                {
                    App_logs al = new App_logs { Description = ex.Message, Method_Name = System.Reflection.MethodBase.GetCurrentMethod().Name };
                    al.Add();
                }
            }

            DBException_ = _DBException;
            return success;
        }
        public bool Save(out bool DBException_)
        {
            bool _DBException = false;
            bool success = false;
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.Projects.Attach(this);
                    _db.Entry(this).State = EntityState.Modified;
                    _db.SaveChanges();
                    success = true;
                }
                catch (Exception ex)
                {
                    App_logs al = new App_logs { Description = ex.Message, Method_Name = System.Reflection.MethodBase.GetCurrentMethod().Name };
                    al.Add();
                    _DBException = true;
                }

            }
            DBException_ = _DBException;
            return success;
        }
    
    }

  


}

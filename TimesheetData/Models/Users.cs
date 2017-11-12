using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TimesheetData.Models
{
    public class Users : CommonBaseModel
    {
        public string FullName{ get; set; }
        public string EmailID { get; set; }
        [ForeignKey("LookupItems")]
        public long RoleIDLookupID { get; set; }
        public virtual LookupItems Clients { get; set; }
        public bool isSuperAdmin { get; set; }
        public bool isApprover { get; set; }
        public bool isActive { get; set; }
        public void Add()
        {
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.Users.Add(this);
                    _db.SaveChanges();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public bool Save(out bool DBException_)
        {
            bool _DBException = false;
            bool success = false;
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.Users.Attach(this);
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
        public static List<Users> GetUsers()
        {
            List<Users> _Items = new List<Users>();
            try
            {
                using (TSModel _db = new TSModel())
                {
                    try
                    {
                        var _Data = from p in _db.Users select p;
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
        public static Users Lookup(long ID_)
        {
            Users _Items = new Users();
            try
            {
                var _Data = Users.GetUsers();
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
    }
}

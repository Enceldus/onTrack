using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace TimesheetData.Models
{
  public  class ProjectAndUserMapping : CommonBaseModel
    {
        [ForeignKey("ProjectsMap")]
        public long? Project_ID { get; set; }
        public virtual Projects Projects { get; set; }
        [ForeignKey("UsersMap")]
        public long? User_ID { get; set; }
        public virtual Users Users { get; set; }
        public bool Add(out bool DBException_)
        {
            bool _DBException = false;
            bool success = false;
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.ProjectAndUserMapping.Add(this);
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
                    _db.ProjectAndUserMapping.Attach(this);
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
        public static List<ProjectAndUserMapping>GetAllProjectAndUserMapping()
        {
            List<ProjectAndUserMapping> _Items = new List<ProjectAndUserMapping>();
            try
            {
                using (TSModel _db = new TSModel())
                {
                    try
                    {
                        var _Data = from p in _db.ProjectAndUserMapping select p;
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
        public static ProjectAndUserMapping Lookup(long ID_)
        {
            ProjectAndUserMapping _Items = new ProjectAndUserMapping();
            try
            {
                var _Data = ProjectAndUserMapping.GetAllProjectAndUserMapping();
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
        public static List<ProjectAndUserMapping> LookupByPojID(long P_ID_)
        {
            List<ProjectAndUserMapping> _Items = new List<ProjectAndUserMapping>();
            try
            {
                var _Data = ProjectAndUserMapping.GetAllProjectAndUserMapping();
                if (_Data != null && _Data.Count() > 0)
                {
                    var _Result = _Data.Where(x => x.Project_ID == P_ID_);
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
        public static List<ProjectAndUserMapping> LookupByUserID(long U_ID_)
        {
            List<ProjectAndUserMapping> _Items = new List<ProjectAndUserMapping>();
            try
            {
                var _Data = ProjectAndUserMapping.GetAllProjectAndUserMapping();
                if (_Data != null && _Data.Count() > 0)
                {
                    var _Result = _Data.Where(x => x.User_ID == U_ID_);
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
    }
}

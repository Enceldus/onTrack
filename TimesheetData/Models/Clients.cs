using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;


namespace TimesheetData.Models
{
   public class Clients : CommonBaseModel
    {
        public string Client_Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public bool? IsActive { get; set; }

        public static List<Clients> GetClients()
        {
            List<Clients> _Items = new List<Clients>();
            try
            {                
                using (TSModel _db = new TSModel())
                {
                    try
                    {
                        var _Data = from p in _db.Clients select p;
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

        public bool Add(out bool DBException_)
        {
            bool _DBException = false;
            bool success = false;
            using (TSModel _db = new TSModel())
            {
                try
                {
                    _db.Clients.Add(this);
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
                    _db.Clients.Attach(this);
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
        public static List<Clients> Lookup(string Client_Name_)
        {
            List<Clients> _Items = new List<Clients>();
            try
            {
                var _Data = Clients.GetClients();
                if (_Data != null && _Data.Count() > 0)
                {
                    var _Result = _Data.Where(x => x.Client_Name.Trim().ToUpper() == Client_Name_.Trim().ToUpper());
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
        public static Clients Lookup(long ID_)
        {
            Clients _Items = new Clients();
            try
            {
                var _Data = Clients.GetClients();
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
        public static Clients LookupOrAdd(Clients Client_)
        {
            List<Clients> _Found = Clients.Lookup(Client_.Client_Name);
            try
            {
                if (_Found != null && _Found.Count() > 0)
                {
                    Client_ = _Found.FirstOrDefault();
                }
                else
                {
                    Client_.CreatedByUserID = Client_.CreatedByUserID;
                    Client_.Client_Name = Client_.Client_Name;
                    Client_.Address = Client_.Address;
                    Client_.City = Client_.Client_Name;
                    Client_.State = Client_.State;
                    Client_.ZipCode = Client_.ZipCode;
                    Client_.IsActive = Client_.IsActive;
                    Client_.CreatedDate = DateTime.Now;
                    bool DBException_ = false;
                    Client_.Add(out DBException_);

                    if (DBException_)
                    {
                        App_logs al = new App_logs { Description ="Fail", Method_Name = System.Reflection.MethodBase.GetCurrentMethod().Name };
                        al.Add();
                       
                    }
                    else
                    {
                        App_logs al = new App_logs { Description = "Added", Method_Name = System.Reflection.MethodBase.GetCurrentMethod().Name };
                        al.Add();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                App_logs al = new App_logs { Description = ex.Message, Method_Name = System.Reflection.MethodBase.GetCurrentMethod().Name };
                al.Add();               
            }
            return Client_;
        }
    }


}

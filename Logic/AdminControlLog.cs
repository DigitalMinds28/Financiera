using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class AdminControlLog
    {
        AdminControlDat objAdm = new AdminControlDat();

        // procedimiento para mostar
        public DataSet showAdminControl()
        {
            return objAdm.showAdminControl();
        }
        // procedimiento para guardar
        public bool saveAdminControl(string _post, int _idAccount, int _idManager)
        {
            return objAdm.saveAdminControl(_post, _idAccount, _idManager);
        }
        // procedimiento para actualizar
        public bool updateAdminControl(int _idControlAdmin, string _post, int _idAccount, int _idManager)
        {
            return objAdm.updateAdminControl(_idControlAdmin, _post, _idAccount, _idManager);
        }
        public bool deleteAdminControl(int _idControlAdmin)
        {
            return objAdm.deleteAdminControl(_idControlAdmin);
        }
    }
}
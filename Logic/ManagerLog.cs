using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class ManagerLog
    {
        ManagerDat objMan = new ManagerDat();
        // procedimiento para mostar
        public DataSet showManager()
        {
            return objMan.showManager();
        }
        // procedimiento para guardar
        public bool saveManager(string _admName, string _admLastname)
        {
            return objMan.saveManager(_admName, _admLastname);
        }
        // procedimiento para actualizar
        public bool updateManager(int _idManager, string _admName, string _admLastname)
        {
            return objMan.updateManager(_idManager, _admName, _admLastname);
        }
        // procedimiento para eliminar
        public bool deleteManager(int _idManager)
        {
            return objMan.deleteManager(_idManager);
        }
        public DataSet showManagerDDL()
        {
            return objMan.showManagerDDL(); ;
        }
    }
}
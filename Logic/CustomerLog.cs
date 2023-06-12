using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class CustomerLog
    {
        CustomerDat objCus = new CustomerDat();

        // procedimiento para mostar
        public DataSet showCustomer()
        {
            return objCus.showCustomer();
        }
        // procedimiento para guardar
        public bool saveCustomer(int _identification, string _name, string _lastname, string _phone)
        {
            return objCus.saveCustomer(_identification, _name, _lastname, _phone);
        }
        // procedimiento para actualizar
        public bool updateCustomer(int _idCustomer, int _identification, string _name, string _lastname, string _phone)
        {
            return objCus.updateCustomer(_idCustomer, _identification, _name, _lastname, _phone);
        }
        // procedimiento para eliminar
        public bool deleteCustomer(int _idCustomer)
        {
            return objCus.deleteCustomer(_idCustomer);
        }
        public DataSet showCustomerDDL()
        {
            return objCus.showCustomerDDL();
        }
    }
}
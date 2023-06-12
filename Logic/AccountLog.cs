using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class AccountLog
    {
    
            AccountDat objAcco = new AccountDat();

            // procedimiento para mostar
            public DataSet showAccount()
            {
                return objAcco.showAccount();
            }

            // procedimiento para guardar
            public bool saveAccount(int _accountNumber, double _cash, int _idCustomer)
            {
                return objAcco.saveAccount(_accountNumber, _cash, _idCustomer);
            }
            // procedimiento para actualizar
            public bool updateAccount(int _idAccount, int _accountNumber, double _cash, int _idCustomer)
            {

                return objAcco.updateAccount(_idAccount, _accountNumber, _cash, _idCustomer);
            }
            // procedimiento para eliminar
            public bool deleteAccount(int _idAccount)
            {
                return objAcco.deleteAccount(_idAccount);
            }
            // procedimiento para mostrar ciertos atributos
            public DataSet showAccountDDL()
            {
                return objAcco.showAccountDDL();
            }
    }   
}
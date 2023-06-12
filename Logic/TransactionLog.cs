using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class TransactionLog
    {
        TransactionDat objTrans = new TransactionDat();

        // procedimiento para mostar
        public DataSet showTransaction()
        {
            return objTrans.showTransaction();
        }

        // procedimiento para guardar
        public bool saveTransaction(string _dateTime, string _type, double _monto, int _idDestinationAccount, int _Account_origin, int _idLocation)
        {
            return objTrans.saveTransaction(_dateTime, _type, _monto, _idDestinationAccount, _Account_origin, _idLocation);
        }

        // procedimiento para eliminar
        public bool deleteTransaction(int _idTransaction)
        {
            return objTrans.deleteTransaction(_idTransaction);
        }
    }
}
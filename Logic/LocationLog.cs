using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class LocationLog
    {
        LocationDat objLoc = new LocationDat();

        // procedimiento para mostar
        public DataSet showlocation()
        {
            return objLoc.showlocation();
        }
        // procedimiento para guardar
        public bool savelocation(string _placename)
        {
            return objLoc.savelocation(_placename);
        }
        // procedimiento para actualizar
        public bool updatelocation(int _idLocation, string _placename)
        {
            return objLoc.updatelocation(_idLocation, _placename);
        }
        public bool deletelocation(int _idLocation)
        {
            return objLoc.deletelocation(_idLocation);
        }
        public DataSet showlocationDDL()
        {
            return objLoc.showlocationDDL(); ;
        }
    }
}
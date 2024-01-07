using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CNPM.DataAccessTier;

namespace CNPM
{
    class ThamSoBLT
    {
        ThamSoDAT objThamSo = new ThamSoDAT();

        public int GetQD1A()
        {
            return objThamSo.GetQD1A();
        }

        public int GetQD1B()
        {
            return objThamSo.GetQD1B();
        }

        public int GetQD2A()
        {
            return objThamSo.GetQD2A();
        }

        public int GetQD2B()
        {
            return objThamSo.GetQD2B();
        }

        public bool GetQD4()
        {
            return objThamSo.GetQD4();
        }

        public void Save(ThamSo s)
        {
            objThamSo.Save(s);
        }
    }
}

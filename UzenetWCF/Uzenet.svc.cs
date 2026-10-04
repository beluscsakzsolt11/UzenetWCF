using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetWCF.Models;
using UzenetWCF.Services;
using UzenetWCF.Interfaces;

namespace UzenetWCF
{
    public class UzenetService : IUzenetService
    {

        public string CreateUzenet(Models.Uzenet uzenet)
        {
            return new UzenetServices().Create(uzenet);
        }

        public List<Models.Uzenet> GetAllUzenet()
        {
            List<Tablazat> tablazatok = new UzenetServices().Read();
            List<Models.Uzenet> uzenetList = new List<Models.Uzenet>();

            foreach (Tablazat elem in tablazatok)
            {
                uzenetList.Add(elem as Models.Uzenet);
            }
            return uzenetList;
        }


        public string UpdateUzenet(Models.Uzenet uzenet)
        {
            return new UzenetServices().Update(uzenet);
        }

        public string DeleteUzenet(int id)
        {
            return new UzenetServices().Delete(id);
        }

    }
}

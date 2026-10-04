using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetWCF.Models;


namespace UzenetWCF
{
    [ServiceContract]
    public interface IUzenetService
    {

        [OperationContract]

        List<Models.Uzenet> GetAllUzenet();

        [OperationContract]

        string CreateUzenet(Models.Uzenet uzenet);

        [OperationContract]

        string UpdateUzenet(Models.Uzenet uzenet );

        [OperationContract]

        string DeleteUzenet(int id);
        
    }
}

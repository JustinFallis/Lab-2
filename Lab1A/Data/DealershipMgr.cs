using Lab1A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1A.Data
{
    public class DealershipMgr
    {
        public static List<Dealership> DealershipList { get; set; }

        public DealershipMgr()
        {
            DealershipList.Add(new Dealership { Name = "Why", Email = "WhyAmIDoingThis@PleaseHelp.com", PhoneNumber = "905-543-6043" });
            DealershipList.Add(new Dealership { Name = "Car Place", Email = "CarPlace@gmail.com", PhoneNumber = "903-763-4543" });
            DealershipList.Add(new Dealership { Name = "Devons Cars", Email = "DevonsCars@hotmail.com", PhoneNumber = "365-008-6341" });
        }

        //GET
        public List<Dealership> Get()
        {
            return DealershipList;
        }

        public Dealership GetDealership(int ID)
        {
            return DealershipList[ID];
        }

        public String PutDealership(int ID, Dealership dealership)
        {
            if(DealershipList.Count() <= ID)
            {
                var name = dealership.Name;
                var email = dealership.Email;
                var phone = dealership.PhoneNumber;
                DealershipList[ID].Name = name;
                DealershipList[ID].Email = email;
                DealershipList[ID].PhoneNumber = phone;

                return $"Updated Dealership item {ID} with the name {name}, email {email}, phone number {phone}.";
            } else
            {
                return $"Item with the ID of {ID} doesn't exist.";
            }
        }

        public Dealership PostDealership(Dealership dealership)
        {
            if((dealership.Name != null || dealership.Name != "") && (dealership.Email != null || dealership.Email != ""))
            {
                DealershipList.Add(dealership);
                return dealership;
            }
               

            return null;

        }
        public String DeleteDealership(int ID)
        {
            if (DealershipList.Count() <= ID)
            {
                DealershipList.RemoveAt(ID);
                return $"Dealership item with the ID of {ID} deleted.";
            } else
            {
                return $"Dealership item with ID of {ID} couldn't be deleted.";
            }
        }
    }
}

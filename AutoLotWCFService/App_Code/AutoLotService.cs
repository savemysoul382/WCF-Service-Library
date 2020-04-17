using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;

public class AutoLotService : IAutoLotService
{
    public AutoLotService()
    {
        Mapper.Initialize(cfg => cfg.CreateMap<inventory, InventoryRecord>());
    }

    public void InsertCar(string make, string color, string petname)
    {
        var repo = new inventoryRepo();
        repo.Add(new inventory { Color = color, Make = make, PetName = petname });
        repo.Dispose();
    }

    public void InsertCar(InventoryRecord car)
    {
        var repo = new inventoryRepo();
        repo.Add(new inventory { Color = car.Color, Make = car.Make, PetName = car.PetName });
        repo.Dispose();
    }

    public List<InventoryRecord> GetInventory()
    {
        var repo = new inventoryRepo();
        var records = repo.GetAll();
        var results = Mapper.Map<List<InventoryRecord>>(records);
        repo.Dispose();
        return results;
    }
}
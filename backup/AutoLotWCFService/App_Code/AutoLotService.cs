using System.Collections.Generic;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class AutoLotService : IAutoLotService
{
    private MapperConfiguration config;
    public AutoLotService()
    {
        config = new MapperConfiguration(cfg => {
            cfg.CreateMap<inventory, InventoryRecord>();
        });
        //Mapper.Initialize(cfg => cfg.CreateMap<inventory, InventoryRecord>());
    }

    public void InsertCar(string make, string color, string petname)
    {
        var repo = new inventoryRepo();
        repo.Add(new inventory {Color = color, Make = make, PetName = petname});
        repo.Dispose();
    }

    public void InsertCar(InventoryRecord car)
    {
        var repo = new inventoryRepo();
        repo.Add(
            new inventory
            {
                Color = car.Color,
                Make = car.Make,
                PetName = car.PetName
            });
        repo.Dispose();
    }

    public List<InventoryRecord> Getlnventory()
    {
        var repo = new inventoryRepo();
        var records = repo.GetAll();
        var results = this.config.CreateMapper().Map<List<InventoryRecord>>(records);
        repo.Dispose();
        return results;
    }
}

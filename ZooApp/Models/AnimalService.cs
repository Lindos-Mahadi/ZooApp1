using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZooApp.DAL;

namespace ZooApp.Models
{
    public class AnimalService
    {
        ZooContext db = new ZooContext();
        public List<ViewAnimal> GetAnimals()
        {
            List<Animal> animals = db.Animals.ToList();

            List<ViewAnimal> viewAnimals = new List<ViewAnimal>();

            foreach (Animal animal in animals)
            {
                ViewAnimal viewAnimal = new ViewAnimal()
                {
                    Id = animal.Id,
                    Origin = animal.Origin,
                    Quantity = animal.Quantity,
                    Food = animal.Food,
                    Name = animal.Name
                };
                viewAnimals.Add(viewAnimal);
            }
            return viewAnimals;
        }

        public ViewAnimal GetAnimal(int id)
        {
            Animal animal = new Animal();
            db.Animals.Find(id);
            return new ViewAnimal()
            {
                Id = animal.Id,
                Origin = animal.Origin,
                Quantity = animal.Quantity,
                Food = animal.Food,
                Name = animal.Name
            };
        }

        public bool Save(Animal animal)
        {
         Animal add = db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }

        public bool Update(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(Animal animal)
        {
            Animal dbAnimal = db.Animals.Find(animal.Id);
            db.SaveChanges();
            return true;
        }

        public Animal GetDbAnimal(int id)
        {
            return db.Animals.Find(id);
        }
    }
}

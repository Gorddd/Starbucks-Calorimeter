﻿using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers;

public interface IBottledDrinkManager
{
    Task<List<BottledDrink>> GetAll(); //AsNoTracking
    Task<BottledDrink> Get(int id);
    Task<BottledDrink> Get(string name);
    Task Add(BottledDrink bottledDrink);
    Task Update(BottledDrink bottledDrink);
    Task Delete(int id);
    Task<List<BottledDrink>> Filter(string name);
}

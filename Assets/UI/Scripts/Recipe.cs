using System.Collections;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public static Hashtable recipes = new Hashtable();

    void Start()
    {
        recipes.Add("SimpleSalad", new string[] { "Простой салат", "Помидор", "Огурец"});
        recipes.Add("SimpleSaladSpices", new string[] { "Соль" });
        recipes.Add("SimpleSaladScore", new int[] {100, 250});

        recipes.Add("RussianSalad", new string[] { "Оливье", "Помидор", "Огурец", "Колбаса", "Картошка" });
        recipes.Add("RussianSaladSpices", new string[] { "Соль" });
        recipes.Add("RussianSaladScore", new int[] { 150, 500 });

        recipes.Add("AvocadoSalad", new string[] { "Салат с авокадо", "Помидор", "Авокадо", "Огурец" });
        recipes.Add("AvocadoSaladSpices", new string[] { "Соль", "Масло" });
        recipes.Add("AvocadoSaladScore", new int[] { 250, 700 });

        recipes.Add("SimpleSaladWithOil", new string[] { "Простой салат с маслом", "Помидор", "Огурец" });
        recipes.Add("SimpleSaladWithOilSpices", new string[] { "Соль", "Масло" });
        recipes.Add("SimpleSaladWithOilScore", new int[] { 125, 275 });
    }
}

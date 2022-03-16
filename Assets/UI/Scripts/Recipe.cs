using System.Collections;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public static Hashtable recipes = new Hashtable();

    void Start()
    {
        recipes.Add("SimpleSalad", new string[] { "������� �����", "�������", "������"});
        recipes.Add("SimpleSaladSpices", new string[] { "����" });
        recipes.Add("SimpleSaladScore", new int[] {100, 250});

        recipes.Add("RussianSalad", new string[] { "������", "�������", "������", "�������", "��������" });
        recipes.Add("RussianSaladSpices", new string[] { "����" });
        recipes.Add("RussianSaladScore", new int[] { 150, 500 });

        recipes.Add("AvocadoSalad", new string[] { "����� � �������", "�������", "�������", "������" });
        recipes.Add("AvocadoSaladSpices", new string[] { "����", "�����" });
        recipes.Add("AvocadoSaladScore", new int[] { 250, 700 });

        recipes.Add("SimpleSaladWithOil", new string[] { "������� ����� � ������", "�������", "������" });
        recipes.Add("SimpleSaladWithOilSpices", new string[] { "����", "�����" });
        recipes.Add("SimpleSaladWithOilScore", new int[] { 125, 275 });
    }
}

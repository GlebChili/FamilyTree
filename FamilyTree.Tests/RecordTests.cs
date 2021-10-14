using Xunit;
using System;
using FamilyTree.Shared.Records;
using System.Collections.Generic;

namespace FamilyTree.Tests;

public class RecordTests
{
    [Fact]
    public void TestPersonStringFormation()
    {
        Person person = new Person
        {
            FirstName = "Ilya",
            LastName = "Ilyin",
            Patronymic = "Vladimirovic",
            BirthDate = new DateOnly(1997, 8, 15),
            ArticleUrl = "meadoc.md",
            FatherId = "Pap",
            MotherId = "Mam"
        };

        Assert.Equal("Ilya-Ilyin-15-08-1997", person.ToString());
    }

    [Fact]
    public void TestParentSearch()
    {
        Person father = new Person
        {
            FirstName = "Alexander",
            LastName = "Krasilich",
            Patronymic = "Alexandrovich",
            BirthDate = new DateOnly(1961, 9, 20)
        };

        Person mothetr = new Person
        {
            FirstName = "Natalia",
            LastName = "Krasilich",
            Patronymic = "Borisovna",
            BirthDate = new DateOnly(1961, 7, 12)
        };

        Person son = new Person
        {
            FirstName = "Gleb",
            LastName = "Krasilich",
            Patronymic = "Alexandrovich",
            BirthDate = new DateOnly(1997, 8, 15),
            FatherId = "Alexander-Krasilich-20-09-1961",
            MotherId = "Natalia-Krasilich-12-07-1961"
        };

        Person[] family = {father, mothetr, son};

        Assert.Equal<Person>(father, son.FindFather(family)!);
        Assert.Equal<Person>(mothetr, son.FindMother(family)!);

        Assert.Equal<Person>(new Person
        {
            FirstName = "Alexander",
            LastName = "Krasilich",
            Patronymic = "Alexandrovich",
            BirthDate = new DateOnly(1961, 9, 20)
        }, son.FindFather(family)!);
    }
}
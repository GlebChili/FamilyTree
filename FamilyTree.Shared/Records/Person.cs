using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FamilyTree.Shared.Records
{
    public record Person
    {
        string firstName = "Invalid";
        string lastName = "Invalid";
        DateOnly birthDate = new DateOnly(1,1,1);

        public string FirstName
        {
            get { return firstName; }
            init { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            init { lastName = value; }
        }

        public string? Patronymic { get; init; }

        public string? FatherId { get; init; }

        public string? MotherId { get; init; }

        public DateOnly BirthDate
        {
            get { return birthDate; }
            init { birthDate = value; }
        }

        public string? ArticleUrl { get; init; }

        public override string ToString()
        {
            return $"{FirstName}-{LastName}-{BirthDate.ToString("dd-MM-yyyy")}";
        }

        public Person? FindFather(ICollection<Person> family)
        {
            if (this.FatherId == null)
            {
                return null;
            }

            foreach (Person familyMember in family)
            {
                if (familyMember.ToString() == this.FatherId)
                {
                    return familyMember;
                }
            }

            return null;
        }

        public Person? FindMother(ICollection<Person> family)
        {
            if (this.MotherId == null)
            {
                return null;
            }

            foreach (Person familyMember in family)
            {
                if (familyMember.ToString() == this.MotherId)
                {
                    return familyMember;
                }
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses;

    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public List<Person> People 
        { 
            get 
            { 
                return people; 
            } 
            set 
            { 
                this.people = value; 
            } 
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.people.MaxBy(p => p.Age);
        }
    }
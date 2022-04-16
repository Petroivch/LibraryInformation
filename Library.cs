using System;

namespace LibraryInformation
{
    public class Library
    {
        String name;
        String type;
        int countPages;
        int foundationYear;
        public Library(String name, String type, int countPages, int foundationYear)
        {
            this.name = name;
            this.type = type;
            this.countPages = countPages;
            this.foundationYear = foundationYear;
        }
        public override string ToString()
        {
            return name + ", " + type + ", " + countPages + ", " + foundationYear;
        }
        public String getName()
        {
            return name;
        }
        public String getType()
        {
            return type;
        }
        public int getPages()
        {
            return countPages;
        }
        public int getYear()
        {
            return foundationYear;
        }
    }
}

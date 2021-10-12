using System;
namespace dbsk3_2018.Models
{
    public class MyModel
    {
        private string text = "";
        private int number = 0;

        public MyModel(string text, int number)
        {
            this.text = text;
            this.number = number;
        }

        //A property to get and set the value of text
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        //A property to get and set the value of number
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                //Prevent the number from being set to a value less than 0
                if (value < 0) value = 0;
                number = value;
            }
        }

        public string TextMultipliedWithNumber()
        {
            string newString = "";
            foreach (char c in this.Text)
            {
                for (int i = 0; i < this.Number; i++)
                {
                    newString += c;
                }
            }
            return newString;
        }

    }
}

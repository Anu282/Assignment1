using System;
using System.Collections.Generic;

namespace Quadrant
{
     /*Self Reflection: Time taken :1 week
      *Learnings: string, arrays,lists,string manipulations, Console methods
      *Recommendations:https://docs.microsoft.com/en-us/dotnet/csharp/
      */
    class Program
    {
        public static bool JudgeCircle(string moves)
        {
            /*Store the moves into a dictionary,
             * every character is assigned with integer array of length 2 describing x and y coordinates
            */
            string movesfinal = moves.ToUpper();
            int xcoordinate=0, ycoordinate = 0;
            var dict = new Dictionary<char, int[]>();
            dict['R'] = new int[] { 1, 0 };
            dict['L'] = new int[] { -1, 0 };
            dict['U'] = new int[] { 0, 1 };
            dict['D'] = new int[] { 0, -1 };
            /*Sum the x coordinates and ycoordinates if they are both zero, the robot has returned to its original position*/
            foreach( var i in movesfinal)
            {
                var s = dict[i];
                xcoordinate += s[0];
                ycoordinate += s[1];

            }
            if(xcoordinate==0 && ycoordinate==0)
            { 
                return true;
            }
            else
            {
                return false;
            }
         
        }
        public static bool CheckIfPangram(string sentence)
        {
            int[] count = new int[26];
            //if the sentence length is less than 26, it is not pangram
            if (sentence.Length < 26)
            {
                return false;
            }
            else
            {   //for every character present in the sentence, increment the character count
                foreach (char c in sentence)
                {
                    count[c - 'a']++;
                }
                //if  count is zero for any character the sentence is not a pangram
                foreach (char c in count)
                {
                    if (c == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static int NumIdenticalPairs(int[] nums)
        {
            int count = 0;
            //find the repeating nums by iterating the array twice, second iteration starts from index i+1
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int PivotIndex(int[] nums)
        {
            try
            {   //Calculate the totalsum
                int totalsum = 0, leftsum = 0;
                if (nums.Length == 0)
                {
                    return -1;
                }
                foreach (var i in nums)
                    totalsum += i;

                /* 
                 subtract ith value from totalsum for every iteration and check if it is equal to leftsum
                if its not equal add ith iteration value to leftsum*/
                for (int i = 0; i < nums.Length; i++)
                {
                    if ((totalsum = (totalsum - nums[i])) == leftsum)
                    {
                        return i;
                    }
                    else
                    {
                        leftsum += nums[i];
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }


        public static string MergeAlternately(string word1, string word2)
        {
            string result = "";
            if (word1.Length == 0 && word2.Length == 0)
            {
                return string.Empty;
            }
            else
            {   /*for every iteration append individual characters of word1 and word2 alternatively*/
                for (int i = 0; i < word1.Length || i < word2.Length; i++)
                {
                    if (i < word1.Length)
                    {
                        result += word1[i];
                    }
                    if (i < word2.Length)
                    {
                        result += word2[i];
                    }

                }
            }

            return result.ToString();
        }
        private static string ToGoatLatin(string sentence)
        {
            try
            { 
                string results = "";
                // write your code here.
                char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
                char[] consonants = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
                string sentencelower = sentence.ToLower();
                string[] words = sentencelower.Split(" ");
                string initial = "a";

                foreach (string word in words)
                {
                    foreach (char c in vowels)
                    {   //if word is a vowel append 'ma' 
                        if (word.StartsWith(c))
                        {
                            results += word + "ma" + initial + " ";

                        }
                    }
                    foreach (char c in consonants)
                    {   //if the word is consonant append word[0]+ 'ma' at the end
                        if (word.StartsWith(c))
                        {
                            results += word.Remove(0, 1) + word[0] + "ma" + initial + " ";

                        }
                    }
                    //initial keeps updating for every iteration
                    initial += "a";
                }

                return results.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");            
            string moves = Console.ReadLine();            
            bool pos= JudgeCircle(moves);
            if (pos) 
            { 
                Console.WriteLine("The Robot return’s to initial Position (0,0)"); 
            } 
            else 
            { 
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)"); 
            }
            Console.WriteLine();
            //Question 2:
            Console.WriteLine("Q2 : Enter the string to check for pangram:");            
            string s = Console.ReadLine();     
            bool flag=CheckIfPangram(s);            
            if(flag)            
            {
                Console.WriteLine("Yes, the given string is a pangram");     
            }     
            else     
            {
                Console.WriteLine("No, the given string is not a pangram");     
            }            
            Console.WriteLine();
            //Question 3:
            int[] arr ={1,2,3,1,1,3};     
            int gp=NumIdenticalPairs(arr);     
            Console.WriteLine("Q3:");            
            Console.WriteLine("The number of Identical Pairs in the array are : {0}", gp);
            //Question 4:
            int[] arr1 = { 1, 7, 3, 6, 5, 6 };            
            Console.WriteLine("Q4:");            
            int pivot = PivotIndex (arr1);     
            if(pivot>0)     
            {     
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);     
            }     
            else     
            {            
                Console.WriteLine("The given array has no Pivot index");     
            }     
            Console.WriteLine();
            //Question 5:
            Console.WriteLine("Q5:");            
            Console.WriteLine("Enter the First Word:");           
            String word1=Console.ReadLine();     
            Console.WriteLine("Enter the Second Word:");     
            String word2=Console.ReadLine();            
            String merged= MergeAlternately(word1,word2);            
            Console.WriteLine("The Merged Sentence fromed by both words is {0}",merged);
            //Quesiton 6:
            Console.WriteLine();
            Console.WriteLine("Q6: Enter the sentence to convert:");            
            string sentence = Console.ReadLine();     
            string goatLatin= ToGoatLatin(sentence);            
            Console.WriteLine("Goat Latin for the Given Sentence is {0}",goatLatin);     
            Console.WriteLine();
        }


    }
}

           

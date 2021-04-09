using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UVUServerApp
{
    public class ServerData
    {
        Random rand = new Random();
        string[] facts;
        string[] majors;
        const string FACT_FILE = "UVUFacts.txt";
        const string MAJOR_FILE = "UVUCourseDescriptions.txt";
        public ServerData()
        {

        }
        /// <summary>
        /// loads the facts and major descriptions files from the bin debug folder
        /// </summary>
        public void LoadFiles()
        {
            try
            {
                facts = File.ReadAllLines(FACT_FILE);
                majors = File.ReadAllLines(MAJOR_FILE);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// returns random uvu fact from the array
        /// </summary>
        /// <returns></returns>
        public string GetUVUFact()
        {
            return facts[rand.Next(facts.Length)];
        }
        /// <summary>
        /// returns random uvu major using the Random class.
        /// </summary>
        /// <returns></returns>
        public string GetUVUMajor()
        {
            return majors[rand.Next(majors.Length)];

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WhoWantsMoney
{
    ///Json Control class which handles writing and reading from json
    class JsonControl
    {
        /// <summary>
        /// Method used to read and convert JSON data from a specified path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Path to the File"></param>
        /// <returns></returns>
        public T ReadJson<T>(string path)
        {
            string data = "";

            using (StreamReader reader = new StreamReader(path))
            {
                try
                {
                    data = reader.ReadToEnd();
                }
                catch(IOException e)
                {
                    ErrorService error = new ErrorService("The file was not found!", "File Error", "err");
                    error.CallErrorWindow();
                }                
            }

            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Method used to write and convert JSON data to a specified path
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Path to the File"></param>
        /// <param name="Object which is to be written"></param>
        public void WriteJson<T>(string path, T dataObjectToBeWritten)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                string parsedJson = JsonConvert.SerializeObject(dataObjectToBeWritten);
                writer.Write(parsedJson);
            }
        }
    }
}

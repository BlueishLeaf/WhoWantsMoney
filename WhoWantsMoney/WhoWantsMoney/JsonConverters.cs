using System;
using Newtonsoft.Json;

namespace WhoWantsMoney
{
    internal class DifficultyEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(int)) return true;
            else return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int difficulty = -1;
            bool parsed = int.TryParse(reader.Value.ToString(), out difficulty);

            if (parsed)
            {
                switch (difficulty)
                {
                    case 0:
                        return Difficulty.Easy;
                    case 1:
                        return Difficulty.Normal;
                    case 2:
                        return Difficulty.Hard;
                    case 3:
                        return Difficulty.Genius;
                    default:
                        return null;
                }
            }
            else return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }
    }
}

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Innovation
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly IDistributedCache _cache;
        private readonly JsonSerializer _serializer = new();

        public JsonStringLocalizer(IDistributedCache cache)
        {
            _cache = cache;
        }

        // Indexer to get a localized string by name
        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value);
            }
        }


        // Indexer to get a localized string with arguments
        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var actualValue = this[name];
                return !actualValue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(actualValue.Value, arguments))
                    : actualValue;
            }
        }


        // Method to retrieve all localized strings
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";

            using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new(stream);
            using JsonTextReader reader = new(streamReader);

            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;

                var key = reader.Value as string;
                reader.Read();
                var value = _serializer.Deserialize<string>(reader);
                yield return new LocalizedString(key, value);
            }
        }


        // Method to retrieve a localized string by key
        //send key and fuction back the language u working on it now
        private string GetString(string key)
        {   //Resources/ar-EG.json
            //Resources/en-US.json
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            var fullFilePath = Path.GetFullPath(filePath);

            //check if file exsist or not
            if (File.Exists(fullFilePath))
            {  
                var cacheKey = $"locale_{Thread.CurrentThread.CurrentCulture.Name}_{key}";
                var cacheValue = _cache.GetString(cacheKey);

                if (!string.IsNullOrEmpty(cacheValue))
                    return cacheValue;

                //this all make me if send key(x) read all value that have
                var result = GetValueFromJSON(key, fullFilePath);

                if (!string.IsNullOrEmpty(result))
                    _cache.SetString(cacheKey, result);

                return result;
            }

            return string.Empty;
        }



        // Method to retrieve a localized string value from JSON file by key
        //where the json file that read from it data and propertyname is the readen key
        private string GetValueFromJSON(string propertyName, string filePath)
        {
            if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(filePath))
                return string.Empty;

            using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new(stream);
            using JsonTextReader reader = new(streamReader);

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value as string == propertyName)
                {
                    reader.Read();
                    return _serializer.Deserialize<string>(reader);
                }
            }

            return string.Empty;
        }
    }
}

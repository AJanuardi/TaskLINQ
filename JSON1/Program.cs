using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace JSONtest
{
    class Program
    {
        static void Main(string[] args)
        {
            
             string json = @"[{
                                ""id"": 323,
                                ""username"": ""rinood30"",
                                ""profile"": {
                                ""full_name"": ""Shabrina Fauzan"",
                                ""birthday"": ""1988-10-30"",
                                ""phones"": [
                                    ""08133473821"",
                                    ""082539163912"",
                                ],
                                },
                                ""articles"": [
                                {
                                    ""id"": 3,
                                    ""title"": ""Tips Berbagi Makanan"",
                                    ""published_at"": ""2019-01-03T16:00:00""
                                },
                                {
                                    ""id"": 7,
                                    ""title"": ""Cara Membakar Ikan"",
                                    ""published_at"": ""2019-01-07T14:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 201,
                                ""username"": ""norisa"",
                                ""profile"": {
                                ""full_name"": ""Noor Annisa"",
                                ""birthday"": ""1986-08-14"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 82,
                                    ""title"": ""Cara Membuat Kue Kering"",
                                    ""published_at"": ""2019-10-08T11:00:00""
                                },
                                {
                                    ""id"": 91,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                },
                                {
                                    ""id"": 31,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 42,
                                ""username"": ""karina"",
                                ""profile"": {
                                ""full_name"": ""Karina Triandini"",
                                ""birthday"": ""1986-04-14"",
                                ""phones"": [
                                    ""06133929341""
                                ],
                                },
                                ""articles"": []
                            },
                            {
                                ""id"": 201,
                                ""username"": ""icha"",
                                ""profile"": {
                                ""full_name"": ""Annisa Rachmawaty"",
                                ""birthday"": ""1987-12-30"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 39,
                                    ""title"": ""Tips Berbelanja Bulan Tua"",
                                    ""published_at"": ""2019-04-06T07:00:00""
                                },
                                {
                                    ""id"": 43,
                                    ""title"": ""Cara Memilih Permainan di Steam"",
                                    ""published_at"": ""2019-06-11T05:00:00""
                                },
                                {
                                    ""id"": 58,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-09-12T04:00:00""
                                }
                                ]
                            }]";
    
           
           var list = JsonConvert.DeserializeObject<List<User>>(json);

           Console.WriteLine("======================================");
           Console.WriteLine("User yang tidak memiliki nomor telepon");
           var result1 = list.Where(i => (i.Profile.Phones).Length == 0);
           foreach(var x in result1)
           {   
              Console.WriteLine(x.Username);
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki Artikel");
           var result2 = list.Where(i => (i.articles).Count > 1);
           foreach(var x in result2)
           {   
                Console.WriteLine(x.Username);
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki kata Annis pada nama");
           var result3 = list.Where(i => (i.Profile.Fullname).Contains("Annis"));
           foreach(var x in result3)
           {
               Console.WriteLine(x.Username);
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang lahir pada tahun 1986");
           var result4 = list.Where(i => (i.Profile.Birthday).Year == 1986);
           foreach(var x in result4)
           {
               Console.WriteLine(x.Username);
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki artikel pada tahun 2020");
           try
           {
               var result5 = from l in list from x in l.articles where ((x.published_at).Year == 2020) select l.Profile.Fullname;
               foreach(var i in result5)
               {
                   Console.WriteLine(i);
               }
           }
           catch (Exception e)
           {
               Console.WriteLine("Artikel Tidak Ditemukan");
               throw;
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki judul tips");
           try
           {
               var result6 = from l in list from x in l.articles where ((x.title).Contains("Tips")) select l.Profile.Fullname;
               foreach(var i in result6)
               {
                   Console.WriteLine(i);
               }
           }
           catch (Exception e)
           {
               Console.WriteLine("Artikel Tidak Ditemukan");
               throw;
           }

            
           Console.WriteLine("======================================");
           Console.WriteLine("User yang publish artikel sebelum Agustus 2019");
           var filterDate = new DateTime(2019,08,01);
           try
           {
               var results = from l in list from x in l.articles where ((x.published_at) < filterDate) select l.Profile.Fullname;
               var result7 = results.Distinct();
               foreach(var i in result7)
               {
                   Console.WriteLine(i);
               }
           }
           catch (Exception e)
           {
               Console.WriteLine("Artikel Tidak Ditemukan");
               throw;
           }
           Console.WriteLine("======================================");    
        }
    }
    public class User
    {
        [JsonProperty("id")]
        public int Id {get;set;}
        [JsonProperty("username")]
        public string Username {get;set;}
        public Profile Profile {get;set;}
        public List<Articles> articles {get;set;} = null;

    }

    public class Profile
    {
        [JsonProperty("id")]
        public int Id {get;set;}
        [JsonProperty("full_name")]
        public string Fullname {get;set;}
        [JsonProperty("birthday")]
        public DateTime Birthday {get;set;}
        [JsonProperty("phones")]
        public string[] Phones {get;set;} = {};

    }

    public class Articles
    {
        [JsonProperty("id")]
        public int id {get;set;}
        [JsonProperty("title")]
        public string title {get;set;}
        [JsonProperty("published_at")]
        public DateTime published_at {get;set;}
    }
    
}
using first.search;
using second.search;
using Npgsql;
using _config;
using Dapper;
using third.search;
using fourth.search;
using System.Xml.Linq;

namespace _commands
{
    public static class commands
    {
        public static List<search1> first_search()
        {
            var list = new List<search1>();
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var query = "select distinct first_name from actor limit 10";
                list = connection.Query<search1>(query).ToList();
                return list;
            }
        }
        public static List<search2> second_search()
        {
            var list = new List<search2>();
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var query = "select title,description from film where length > 100 limit 5";
                list = connection.Query<search2>(query).ToList();
                return list;
            }
        }
        public static List<search3> third_search(string name)
        {
            var list = new List<search3>();
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                var query = $"select title,rating from film where rating >= 'G' and rating <= 'PG-13' and title like '%{name}%'";
                list = connection.Query<search3>(query).ToList();
                for(var i = list.Count-1; i>=0;i--)
                {
                    switch (list[i].rating)
                    {
                        case "G":
                            list[i].amount = 178; break;
                        case "PG":
                            list[i].amount = 194; break;
                        case "PG-13":
                            list[i].amount = 223; break;
                    }
                }
                return list;
            }
        }
        public static List<search4> fourth_search()
        {
            var list = new List<search4>();
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                int id = 0;
                var s1 = "select actor_id from film_actor group by actor_id having count(actor_id) > 20";
                var sublist = connection.Query<subsearch4>(s1).ToList();
                var subquery = new List<search4>();
                for (var i = 0; i < 10; i++)
                {
                    id = Convert.ToInt32(sublist[i].actor_id);
                    var query = $"select first_name, last_name from actor where actor_id = {id}";
                    subquery = connection.Query<search4>(query).ToList();
                    list.Add(new search4 {
                        first_name = subquery[0].first_name,
                        last_name = subquery[0].last_name
                        });
                }
                return list;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JamFactory.Controller.Database {
    class OptimeringDatabaseFacade {
        //Database 20
        private static SqlConnection dbconn;
        private static string _connectionString = "Server=ealdb1.eal.local; User ID=ejl20_usr; Password=Baz1nga20; Database=EJL20_DB";

        public List<Model.Product> GetAllProducts() {
            List<Model.Product> Products = new List<Model.Product>();
            try {
                ConnectDB();
        
                SqlCommand cmd = new SqlCommand("GetAllProducts", dbconn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.HasRows && rdr.Read()) {
                    int RecipeID = (int)rdr["RecipeID"];
                    string Variant = (string)rdr["Variant"];
                    int Size = (int)rdr["Size"];
                    int FruitContent = (int)rdr["FruitContent"];
                    double Price  = (double)rdr["Price"];
                    Model.Product p = new Model.Product(RecipeID, Variant, Size, FruitContent, Price);
                    Products.Add(p);
                }

                CloseDB();

                return Products;
            }
            catch (Exception e) {
                
                throw new Exception("Error in getting all Products" + e.Message);
            }
        }

        public List<Model.IngredientLine> GetAllIngredientLines() {
            List<Model.IngredientLine> IngredientLines = new List<Model.IngredientLine>();

            try {
                ConnectDB();
        
                SqlCommand cmd = new SqlCommand("GetAllIngredientLines", dbconn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.HasRows && rdr.Read()) {
                    int IngredientLineAmount = (int)rdr["IngredientLine.Amount"];
                    string RecipeName = (string)rdr["Recipe.Name"];
                    string Dokumentation = (string)rdr["Recipe.Dokumentation"];
                    string Correspondence = (string)rdr["Recipe.Correspondence"];
                    //int TestVariant = (int)rdr["Recipe.TestVariant"];
                    double Price = (double)rdr["Ingredient.Price"];
                    int IngredientAmount = (int)rdr["Ingredient.Amount"];
                    string IngredientName = (string)rdr["Ingredient.Name"];
                    int Gram = (int)rdr["Fruit.Gram"];
                    string Season = (string)rdr["Fruit.Season"];
                    Model.Recipe r = new Model.Recipe(RecipeName, Dokumentation, Correspondence);
                    Model.Fruit f = new Model.Fruit(IngredientName, Price, IngredientAmount, Gram, Season);
                    Model.IngredientLine il = new Model.IngredientLine(IngredientLineAmount, r, f);
                    IngredientLines.Add(il);
                }

                CloseDB();

                return IngredientLines;
            }
            catch (Exception) {
                
                throw;
            }
        }

        private static void ConnectDB() {
            dbconn = new SqlConnection(_connectionString);
            dbconn.Open();
        }

        private static void CloseDB() {
            dbconn.Close();
        }

    }
}

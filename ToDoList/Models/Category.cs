using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Category
  {
    private string _name;
    private int _id;
    private List<Item> _items;

    public Category(string categoryName, int id = 0)
    {
      _name = categoryName;
      _id = id;
      _items = new List<Item>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public void AddItem(Item item)
    {
      _items.Add(item);
    }

    public static void ClearAll()
    {
      
    }

    public static List<Category> GetAll()
    {
     
    }

    public static Category Find(int id)
    {
      
    }

    public List<Item> GetItems()
    {
      return _items;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = new MySqlCommand ("DELETE FROM categories WHERE id = @CategoryId; DELETE FROM categories_items WHERE category_id = @CategoryId;", conn);
      MySqlParameter categoryIdParameter = new MySqlParameter();
      categoryIdParameter.ParameterName = "@CategoryId";
      categoryIdParameter.Value = this.GetId();
      cmd.Parameters.Add(categoryIdParameter);
      cmd.ExecuteNonQuery();
      if(conn!=null)
      {
        conn.Close();
        }
    }

    public override bool Equals(System.Object otherCategory)
    {
      if (!(otherCategory is Category))
      {
        return false;
      }
      else
      {
        Category newCategory = (Category) otherCategory;
        bool idEquality = this.GetId().Equals(newCategory.GetId());
        bool nameEquality = this.GetName().Equals(newCategory.GetName());
        return (idEquality && nameEquality);
      }
    }

  }
}

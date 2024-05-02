using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeshopCsharp.modle
{
    public class Product
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public string PType { get; set; }
        public string PSize { get; set; }
        public int PPrice { get; set; }
        public byte[] PImage { get; set; }
        public int PStatus { get; set; }
        public int PPriceOriginal { get; set; }
        public string PExp { get; set; }
       
    }
    
   



    public class ProductRepository {

        public readonly IDbConnection dbConnection;
        public ProductRepository(IDbConnection connection) {
            dbConnection = connection ?? throw new AggregateException(nameof(connection));
        
        }

        public IEnumerable<Product> GetAllProducts() {

            return dbConnection.Query<Product>("SELECT * FROM tb_products");

        }

        public IEnumerable< Product> GetProductByType(Product product) {
            return dbConnection.Query<Product>("SELECT * FROM tb_products WHERE pType=@pType",product);
        }

        public IEnumerable<Product> GetProductByStatus(Product product) { 
            return dbConnection.Query<Product>("SELECT * FROM tb_products WHERE pStatus=@pStatus", product);
        }

        public void AddProduct(Product product) {
            string sql= "INSERT INTO tb_products (pName, pType, pSize, pImage, pStatus, pPriceOriginal, pExp) " +
                       "VALUES (@PName, @PType, @PSize, @PImage, @PStatus, @PPriceOriginal, @PExp)";
            try
            {
                dbConnection.Query<Product>(sql, product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ຂະໜາດຂອງຮູບໃຫ່ຍເກີນໄປ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateProduct(Product product)
        {
            string sql = "UPDATE tb_products SET pName=@pName,pType=@pType,pSize=@pSize,pImage=@pImage,pStatus=@pStatus,pPriceOriginal=@pPriceOriginal,pExp=@pExp WHERE pId=@pID";

            try {
                dbConnection.Query<Product>(sql,product);
            }
            catch (Exception ex) {
                MessageBox.Show("ຂະໜາດຂອງຮູບໃຫ່ຍເກີນໄປ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void DeteleProduct(Product product) {
            string sql = "DELETE FROM tb_products WHERE pId=@pId";
            try
            {
                dbConnection.Query<Product>(sql, product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ບໍໍ່ມີໃນລະບົບ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }


}

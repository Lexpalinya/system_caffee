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
        public int PAmount { get; set; }
        public int PStatus { get; set; }
        public int PPriceOriginal { get; set; }
        public string PExp { get; set; }
        public byte[] PImage { get; set; }
       
    }
    
   



    public class ProductRepository {

        public readonly IDbConnection dbConnection;
        public ProductRepository(IDbConnection connection) {
            dbConnection = connection ?? throw new AggregateException(nameof(connection));
        
        }


        // Get All Products ----------------------------------------------------------------------
        public IEnumerable<Product> GetAllProducts() {
            try { 
                return dbConnection.Query<Product>("SELECT * FROM tb_products");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<Product>();
            }
        }
        // Get Products By Type -----------------------------------------------------------------------
        public IEnumerable< Product> GetProductByType(Product product) {
            try { 
                
                return dbConnection.Query<Product>("SELECT * FROM tb_products WHERE pType=@pType",product);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<Product>();
            }
        }

        // Get Products By Status -------------------------------------------------------------------------
        public IEnumerable<Product> GetProductByStatus(Product product) { 
            try
            {
                return dbConnection.Query<Product>("SELECT * FROM tb_products WHERE pStatus=@pStatus", product);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error); return Enumerable.Empty<Product>(); }
        }

        // Add Product --------------------------------------------------------------------------------------
        public void AddProduct(Product product) {
            try
            {
                 string sql= "INSERT INTO tb_products (pName, pType, pSize, pAmount,pImage, pStatus, pPriceOriginal, pExp) " +
                       "VALUES (@PName, @PType, @PSize,@PAmount, @PImage, @PStatus, @PPriceOriginal, @PExp)";
                 int rowAffected=   dbConnection.Execute(sql, product);
                if (rowAffected == 1)
                {
                    MessageBox.Show("ບັນທຶກສຳເລັດ", "Save", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ຂະໜາດຂອງຮູບໃຫ່ຍເກີນໄປ"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update Product ---------------------------------------------------------------------------------------
        public void UpdateProduct(Product product)
        {
            try {
                string sql = "UPDATE tb_products SET pName=@pName,pType=@pType,pSize=@pSize,pAmount=@PAmount,pImage=@pImage,pStatus=@pStatus,pPriceOriginal=@pPriceOriginal,pExp=@pExp WHERE pId=@pID";
                int rowAffected=dbConnection.Execute(sql,product);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("ຂະໜາດຂອງຮູບໃຫ່ຍເກີນໄປ"+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        // Update Product Status and Amount ---------------------------------------------------------------------------------
        public void UpdateStatusAndAmount(Product product) {
            try
            {
                string sql = "UPDATE tb_products SET pAmount=@PAmount,pStatus=@pStatus WHERE pId=@pID";
                int rowAffected = dbConnection.Execute(sql, product);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        

        // Delete Product ----------------------------------------------------------------------------------------
        public void DeteleProduct(Product product) {
            try
            {
                string sql = "DELETE FROM tb_products WHERE pId=@pId";
                int rowAffected=dbConnection.Execute(sql, product);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ລົບຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ລົບສຳເລັດ", "DELETE", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ບໍໍ່ມີໃນລະບົບ"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }


}
